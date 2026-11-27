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
        return transactionLog.getTransactionList();
    }

    // Method that passes the transaction list sorted by month and year from the TransactionLog to the caller
    public List<Transaction> CGetTransactionsByMonthAndYear(int month, int year)
    {
        return transactionLog.getTransactionsByMonthAndYear(month, year);
    }

    // Method that passes the transaction list sorted by category from the TransactionLog to the caller
    public List<Transaction> CGetTransactionsByCategory(string category)
    {
        return transactionLog.getTransactionsByCategory(category);
    }

    // Method that passes the transaction list sorted by category and month/year from the TransactionLog to the caller
    public List<Transaction> CGetTransactionsByCategoryAndMonthAndYear(string category, int month, int year)
    {
        return transactionLog.getTransactionsByCategoryAndMonthAndYear(category, month, year);
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
        return transactionLog.removeTransactionById(id);
    }

    public void CAddSampleData()
    {
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 12, 16), 12.50f, "McDonald's");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 12, 10), 13f, "McDonald's");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 12, 28), 15f, "Burger King");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 11, 30), 12.50f, "Wendy's");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 11, 15), 12.50f, "KFC");
        transactionLog.CreateTransaction("fast food", new DateTime(2025, 11, 20), 12.50f, "Taco Bell");
        transactionLog.CreateTransaction("subscription", new DateTime(2025, 12, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("subscription", new DateTime(2025, 11, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("subscription", new DateTime(2025, 10, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("subscription", new DateTime(2025, 9, 1), 12.50f, "Netflix");
        transactionLog.CreateTransaction("subscription", new DateTime(2025, 12, 15), 12.50f, "Hulu");
        transactionLog.CreateTransaction("subscription", new DateTime(2025, 11, 1), 12.50f, "Disney+");
        transactionLog.CreateTransaction("subscription", new DateTime(2023, 1, 15), 12.50f, "YouTube");
        transactionLog.CreateTransaction("fast food", new DateTime(2023, 1, 15), 12.50f, "McDonald's");
        transactionLog.CreateTransaction("fast food", new DateTime(2023, 1, 12), 12.50f, "Burger King");
    }
}