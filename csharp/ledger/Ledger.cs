using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string description, decimal change)
    {
        Date = date;
        Description = description;
        Change = change;
    }

    public DateTime Date { get; }
    public string Description { get; }
    public decimal Change { get; }
}

public static class Ledger
{
    private static readonly IDictionary<string, string> CurrencySymbolsByCode = new Dictionary<string, string>
    {
        {"USD", "$"},
        {"EUR", "€"}
    };
    
    public static LedgerEntry CreateEntry(string date, string description, int change) =>
        new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), description, change / 100.0m);

    private static CultureInfo CreateCulture(string currency, string locale)
    {
        if (!CurrencySymbolsByCode.TryGetValue(currency, out var currencySymbol))
        {
            throw new ArgumentException("Invalid currency");
        }
        
        return locale switch
        {
            "nl-NL" => new CultureInfo(locale)
            {
                NumberFormat = { CurrencySymbol = currencySymbol, CurrencyNegativePattern = 12 },
                DateTimeFormat = { ShortDatePattern = "dd/MM/yyyy" }
            },
            "en-US" => new CultureInfo(locale)
            {
                NumberFormat = { CurrencySymbol = currencySymbol },
                DateTimeFormat = { ShortDatePattern = "MM/dd/yyyy" }
            },
            _ => throw new ArgumentException("Invalid locale")
        };
    }

    private static string PrintHead(string locale) => locale switch
    {
        "en-US" => "Date       | Description               | Change       ",
        "nl-NL" => "Datum      | Omschrijving              | Verandering  ",
        _ => throw new ArgumentException("Invalid locale")
    };

    private static string Truncate(string str, int maxLength)
    {
        if (str.Length <= maxLength)
        {
            return str;
        }

        var truncated = str.Substring(0, Math.Max(0, maxLength - 3));
        return $"{truncated}...";
    }

    private static string Change(IFormatProvider culture, decimal cgh)
    {
        var formatted = cgh.ToString("C", culture);
        return cgh < 0.0m ? formatted : formatted + " ";
    }

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
    {
        var date = entry.Date.ToString("d", culture);
        var description = Truncate(entry.Description, 25);
        var change = Change(culture, entry.Change);

        return $"{date} | {description,-25} | {change,13}";
    }
    
    private static IEnumerable<LedgerEntry> Sort(LedgerEntry[] entries)
    {
        static string OrderLedgerEntry(LedgerEntry entry) => entry.Date + "@" + entry.Description + "@" + entry.Change;
        
        var negatives = entries.Where(e => e.Change < 0).OrderBy(OrderLedgerEntry);
        var positives = entries.Where(e => e.Change >= 0).OrderBy(OrderLedgerEntry);

        return negatives.Concat(positives);
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var culture = CreateCulture(currency, locale);
        var formattedEntries = Sort(entries).Select(entry => PrintEntry(culture, entry));
        var formattedHeader = PrintHead(locale);
        
        return string.Join("\n", formattedEntries.Prepend(formattedHeader));
    }
}