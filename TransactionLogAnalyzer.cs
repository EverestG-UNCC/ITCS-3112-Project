// This class provides methods to create statistics about the transactions.

public class TransactionLogAnalyzer
{

    // Method to calculate the total amount spent in a specific category for a given month of a given year
    public float GetMonthCategoryTotal(List<Transaction> transactions, int month, int year, string category)
    {
        float total = 0;

        foreach (Transaction transaction in transactions)
        {
            if (transaction.Date.Month == month && transaction.Date.Year == year && transaction.Category == category)
            {
                total += transaction.Amount;
            }
        }

        return total;
    }

    // Method to calculate the total amount spent in a specific category for a given year
    public float GetYearCategoryTotal(List<Transaction> transactions, int year, string category)
    {
        float total = 0;

        foreach (Transaction transaction in transactions)
        {
            if (transaction.Date.Year == year && transaction.Category == category)
            {
                total += transaction.Amount;
            }
        }

        return total;
    }


    // Method to calculate the total amount spent in a specific category for each month of a given year
    public List<float> GetMonthlyCategoryTotals(List<Transaction> transactions, int year, string category)
    {
        List<float> monthlyTotals = new List<float>();

        for (int month = 1; month <= 12; month++)
        {
            monthlyTotals.Add(GetMonthCategoryTotal(transactions, month, year, category));
        }

        return monthlyTotals;
    }

    // Method to detect potential subscriptions based on recurring transactions from the same vendor
    public List<string> GetPotentialSubscriptions(List<Transaction> transactions)
    {
        Dictionary<string, int> vendorTransactionCount= new Dictionary<string, int>();

        foreach (Transaction transaction in transactions)
        {
            if (vendorTransactionCount.ContainsKey(transaction.Vendor)) 
            {
                vendorTransactionCount[transaction.Vendor]++; // If the dictionary has record of this vendor, increment its count
            }
            else
            {
                vendorTransactionCount[transaction.Vendor] = 1; // If the dictionary does not have record of this vendor, add it with a count of 1
            }
        }

        List<string> potentialSubscriptions = new List<string>();

        foreach (var vendor in vendorTransactionCount)
        {
            if (vendor.Value >= 3) // Assuming a subscription is detected if there are 3 or more transactions from the same vendor
            {
                potentialSubscriptions.Add(vendor.Key);
            }
        }

        return potentialSubscriptions;
    }

}