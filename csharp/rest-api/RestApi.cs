using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using RestApi.Domain;

namespace RestApi.Api
{
    public class RestApi
    {
        private readonly TransactionService _transactionService;

        public RestApi(string database)
        {
            _transactionService = new TransactionService();

            var data = JsonHelper.Deserialize<IEnumerable<UserSummaryResponse>>(database);
            foreach (var item in data)
            {
                _transactionService.AddUser(item.Name);
                foreach (var (borrower, amount) in item.OwedBy)
                {
                    _transactionService.AddTransaction(item.Name, borrower, amount);
                }
            }
        }

        /// <summary>
        /// Perform a GET request at the given URL
        /// </summary>
        /// <param name="url">Path of the request</param>
        /// <param name="payload">Optional JSON payload of the request</param>
        /// <returns>JSON response</returns>
        public string Get(string url, string payload = null)
        {
            object response = url switch
            {
                "/users" => GetUsers(payload),
                _ => throw new ArgumentException($"Unknown url {url}", nameof(url))
            };

            return JsonHelper.Serialize(response);
        }

        /// <summary>
        /// Perform a POST request at the given URL with the given payload
        /// </summary>
        /// <param name="url">Path of the request</param>
        /// <param name="payload">JSON payload of the request</param>
        /// <returns>JSON response</returns>
        public string Post(string url, string payload)
        {
            object response = url switch
            {
                "/add" => AddUser(payload),
                "/iou" => AddTransaction(payload),
                _ => throw new ArgumentException($"Unknown url {url}", nameof(url))
            };

            return JsonHelper.Serialize(response);
        }

        /// <summary>
        /// Retrieve a list of users.
        /// </summary>
        /// <param name="payload">Optional JSON payload containing a list of users to return</param>
        /// <returns>Summary of the users provided in the payload, or all users when no payload</returns>
        private IEnumerable<UserSummaryResponse> GetUsers(string payload = null)
        {
            if (payload == null)
            {
                return _transactionService.GetUserSummaries().Select(ToUserSummaryResponse);
            }

            var request = JsonHelper.Deserialize<GetUsersRequest>(payload);
            return _transactionService
                .GetUserSummaries(request.Users)
                .Select(ToUserSummaryResponse);
        }

        /// <summary>
        /// Add a new user.
        /// </summary>
        /// <param name="payload">JSON payload containing the name of the user</param>
        /// <returns>The summary of the created user</returns>
        /// <exception cref="ArgumentException">Thrown when the payload is empty</exception>
        private UserSummaryResponse AddUser(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
            {
                throw new ArgumentException("Empty payload");
            }

            var request = JsonHelper.Deserialize<AddUserRequest>(payload);
            var summary = _transactionService.AddUser(request.User);
            return ToUserSummaryResponse(summary);
        }

        /// <summary>
        /// Add a new transaction between two users. 
        /// </summary>
        /// <param name="payload">JSON payload containing the two users and an amount</param>
        /// <returns>The summary for both users after the transaction is completed</returns>
        /// <exception cref="ArgumentException">Thrown when the payload is empty</exception>
        private IEnumerable<UserSummaryResponse> AddTransaction(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
            {
                throw new ArgumentException("Empty payload");
            }

            var request = JsonHelper.Deserialize<AddTransactionRequest>(payload);
            var result = _transactionService.AddTransaction(request.Lender, request.Borrower, request.Amount);
            return new[] {result.Lender, result.Borrower}
                .OrderBy(x => x.User)
                .Select(ToUserSummaryResponse);
        }

        private static UserSummaryResponse ToUserSummaryResponse(UserSummary summary) => new UserSummaryResponse
        {
            Name = summary.User,
            Balance = summary.Balances.Sum(x => x.Value),
            Owes = summary.Balances
                .Where(x => x.Value < 0)
                .ToImmutableSortedDictionary(x => x.Key, x => -x.Value),
            OwedBy = summary.Balances
                .Where(x => x.Value > 0)
                .ToImmutableSortedDictionary(x => x.Key, x => x.Value),
        };
    }

    internal class UserSummaryResponse
    {
        public string Name { get; set; }

        public IDictionary<string, decimal> Owes { get; set; }

        public IDictionary<string, decimal> OwedBy { get; set; }

        public decimal Balance { get; set; }
    }

    internal class GetUsersRequest
    {
        public List<string> Users { get; set; }
    }

    internal class AddUserRequest
    {
        public string User { get; set; }
    }

    internal class AddTransactionRequest
    {
        public string Lender { get; set; }

        public string Borrower { get; set; }

        public decimal Amount { get; set; }
    }

    internal static class JsonHelper
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public static string Serialize<T>(T obj) => JsonConvert.SerializeObject(obj, JsonSerializerSettings);

        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);
    }
}