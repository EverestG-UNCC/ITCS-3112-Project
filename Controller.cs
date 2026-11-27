// This class serves as the controller for the application, coordinating the interaction between the user interface and the transaction log.
public class Controller
{
    UserInterface userInterface;
    TransactionLog transactionLog;
    TransactionLogAnalyzer analyzer;

    // Constructor for the Controller class
    public Controller()
    {
        userInterface = new UserInterface(this);
        transactionLog = new TransactionLog();
        analyzer = new TransactionLogAnalyzer();
    }
    public void Run()
    {
        Console.WriteLine("Controller is running.");
    
        userInterface.Start();

    }

    // Method that passes the transaction list from the TransactionLog to the caller
    public List<Transaction> CGetTransactionList()
    {
        return transactionLog.GetTransactionList();
    }

    // Method that passes the transaction list sorted by month and year from the TransactionLog to the caller
    public List<Transaction> CGetTransactionsByMonthAndYear(int month, int year)
    {
        return transactionLog.GetTransactionsByMonthAndYear(month, year);
    }

    // Method that passes the transaction list sorted by category from the TransactionLog to the caller
    public List<Transaction> CGetTransactionsByCategory(string category)
    {
        return transactionLog.getTransactionsByCategory(category);
    }

    // Method that passes the transaction list sorted by category and month/year from the TransactionLog to the caller
    public List<Transaction> CGetTransactionsByCategoryAndMonthAndYear(string category, int month, int year)
    {
        return transactionLog.GetTransactionsByCategoryAndMonthAndYear(category, month, year);
    }

    // Method that passes arguments to create a transaction and add it to the log
    public void CCreateTransaction(string category, DateTime date, float amount, string vendor)
    {
        transactionLog.CreateTransaction(category, date, amount, vendor);
    }

    // Method that passes the transaction ID to the TransactionLog to retrieve a transaction by its ID
    public Transaction? CGetTransactionById(int id)
    {
        return transactionLog.GetTransactionById(id);
    }

    // Method that passes the transaction ID to the TransactionLog to remove a transaction by its ID
    public bool CRemoveTransactionById(int id)
    {
        return transactionLog.RemoveTransactionById(id);
    }

    // Method that passes transaction list and arguments to calculate the total amount spent in a specific category for a given month of a given year
    public float CGetMonthCategoryTotal(List<Transaction> transactions, int month, int year, string category)
    {
        return analyzer.GetMonthCategoryTotal(transactions, month, year, category);
    }

    // Method that passes transaction list and arguments to calculate the total amount spent in a specific category for a given year
    public float CGetYearCategoryTotal(List<Transaction> transactions, int year, string category)
    {
        return analyzer.GetYearCategoryTotal(transactions, year, category);
    }

    // Method that passes transaction list and arguments to calculate the total amount spent in a specific category for each month of a given year
    public List<float> CGetMonthlyCategoryTotals(List<Transaction> transactions, int year, string category)
    {
        return analyzer.GetMonthlyCategoryTotals(transactions, year, category);
    }

    // Method that passes transaction list to detect potential subscriptions based on recurring transactions from the same vendor
    public List<string> CGetPotentialSubscriptions()
    {
        return analyzer.GetPotentialSubscriptions(transactionLog.GetTransactionList());
    }

    public void CAddSampleData()
    {
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 12, 16), 12.50f, "McDonald's");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 12, 10), 13f, "McDonald's");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 12, 28), 15f, "Burger King");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 11, 30), 12.50f, "Wendy's");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 11, 15), 12.50f, "KFC");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 11, 20), 12.50f, "Taco Bell");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 12, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 11, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 10, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 9, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 12, 15), 12.50f, "Hulu");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 11, 1), 12.50f, "Disney+");
        transactionLog.CreateTransaction("entertainment", new DateTime(2023, 1, 15), 12.50f, "YouTube");
        transactionLog.CreateTransaction("fast food", new DateTime(2023, 1, 15), 12.50f, "McDonald's");
        transactionLog.CreateTransaction("fast food", new DateTime(2023, 1, 12), 12.50f, "Burger King");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 12, 16), 12.50f, "McDonald's");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 12, 10), 13f, "McDonald's");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 12, 28), 15f, "Burger King");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 11, 30), 12.50f, "Wendy's");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 11, 15), 12.50f, "KFC");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 11, 20), 12.50f, "Taco Bell");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 12, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 11, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 10, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 9, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 12, 15), 12.50f, "Hulu");
        transactionLog.CreateTransaction("entertainment", new DateTime(2025, 11, 1), 12.50f, "Disney+");
        transactionLog.CreateTransaction("entertainment", new DateTime(2023, 1, 15), 12.50f, "YouTube");
        transactionLog.CreateTransaction("fast food", new DateTime(2023, 1, 15), 12.50f, "McDonald's");
        transactionLog.CreateTransaction("fast food", new DateTime(2023, 1, 12), 12.50f, "Burger King");
    }
}