using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Domain
{
    /// <summary>
    /// Summary of a user.
    /// </summary>
    internal class UserSummary
    {
        public UserSummary(string user, IDictionary<string, decimal> balances)
        {
            User = user;
            Balances = balances;
        }

        /// <summary>
        /// The user this summary belongs to.
        /// </summary>
        public string User { get; }

        /// <summary>
        /// Amounts this user owes or is owed by other users.
        /// </summary>
        public IDictionary<string, decimal> Balances { get; }
    }

    internal class TransactionService
    {
        private readonly List<string> _users;
        private readonly List<Transaction> _transactions;

        public TransactionService()
        {
            _users = new List<string>();
            _transactions = new List<Transaction>();
        }

        /// <summary>
        /// Retrieve a summary for all users, or the filtered users if provided.
        /// </summary>
        /// <param name="filter">A list of users to return a summary for</param>
        /// <returns>A summary for all users, or the filtered users if provided</returns>
        public IEnumerable<UserSummary> GetUserSummaries(IReadOnlyCollection<string> filter = default) =>
            from user in _users
            where (filter ?? Enumerable.Empty<string>()).Contains(user)
            orderby user
            select GetSummaryForUser(user);

        /// <summary>
        /// Add a new user. It is not possible to add a user that already exists.
        /// </summary>
        /// <param name="user">Name of the user</param>
        /// <returns>The summary of the created user</returns>
        /// <exception cref="InvalidOperationException">Thrown when the user already exists</exception>
        public UserSummary AddUser(string user)
        {
            if (_users.Contains(user))
            {
                throw new InvalidOperationException("User already exists");
            }

            _users.Add(user);
            return GetSummaryForUser(user);
        }

        /// <summary>
        /// Add a new transaction between two users.
        /// </summary>
        /// <param name="lender">The user that lends the amount</param>
        /// <param name="borrower">The user that borrows the amount</param>
        /// <param name="amount">The amount involved in the transaction</param>
        /// <returns>The user summary of both users</returns>
        /// <exception cref="InvalidOperationException">Thrown when it is not possible to add a transaction for the given users</exception>
        public (UserSummary Lender, UserSummary Borrower) AddTransaction(string lender, string borrower, decimal amount)
        {
            if (lender == borrower)
            {
                throw new InvalidOperationException("Cannot owe yourself");
            }

            if (!_users.Contains(lender))
            {
                throw new InvalidOperationException("Lender does not exist");
            }

            if (!_users.Contains(borrower))
            {
                throw new InvalidOperationException("Borrower does not exist");
            }

            _transactions.Add(new Transaction(lender, borrower, amount));
            return (GetSummaryForUser(lender), GetSummaryForUser(borrower));
        }

        private UserSummary GetSummaryForUser(string user)
        {
            var balances = _transactions
                .Where(r => r.Lender == user || r.Borrower == user)
                .Select(r => r.Lender == user ? (r.Borrower, r.Amount) : (r.Lender, -r.Amount))
                .GroupBy(x => x.Item1)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Item2));

            return new UserSummary(user, balances);
        }

        private class Transaction
        {
            public string Lender { get; }
            public string Borrower { get; }
            public decimal Amount { get; }

            public Transaction(string lender, string borrower, decimal amount)
            {
                Lender = lender;
                Borrower = borrower;
                Amount = amount;
            }
        }
    }
}