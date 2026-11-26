public class TransactionLogAnalyzer
{

    // Method to calculate the total amount spent in a specific category for a given month of a given year
    public float getMonthCategoryTotal(List<Transaction> transactions, int month, int year, string category)
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
    public float getYearCategoryTotal(List<Transaction> transactions, int year, string category)
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
    public List<float> getMonthlyCategoryTotals(List<Transaction> transactions, int year, string category)
    {
        List<float> monthlyTotals = new List<float>();

        for (int month = 1; month <= 12; month++)
        {
            monthlyTotals.Add(getMonthCategoryTotal(transactions, month, year, category));
        }

        return monthlyTotals;
    }

}