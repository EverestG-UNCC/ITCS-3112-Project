using System.Transactions;

// This class represents the transaction log for the application.
// It stores a list of all transactions that have occurred.
// It has methods to create, retrieve, and remove transactions from the log.

public class TransactionLog
{
    // Instance variable to hold a list of transactions
    private List<Transaction> transactionList;

    // Constructor for the TransactionLog class
    public TransactionLog()
    {
        transactionList = new List<Transaction>();
    }
    
    // Method for creating a new transaction and adding it to the transaction list
    public void CreateTransaction(string category, DateTime date, float amount, string vendor)
    {
        Transaction newTransaction = new Transaction(category.ToLower().Replace(" ", ""), date, amount, vendor.ToLower());
        transactionList.Add(newTransaction);
    }

    // Getter method to retrieve a transaction by its ID
    public Transaction? GetTransactionById(int id)
    {
        foreach (Transaction transaction in transactionList)
        {
            if (transaction.Id == id)
            {
                return transaction;
            }
        }
        return null;
    }

    // Method to remove a transaction from the list by its ID
    public bool removeTransactionById(int id)
    {
        foreach (Transaction transaction in transactionList)
        {
            if (transaction.Id == id)
            {
                transactionList.Remove(transaction);
                return true;
            }
        }
        return false;
    }

    // Method that sorts a list of transactions by date ascending order
    public List<Transaction> sortTransactionsByDate(List<Transaction> transactions)
    {
        transactions.Sort((t1, t2) => t1.Date.CompareTo(t2.Date));
        return transactions;
    }

    // Getter method to retrieve the list of transactions
    public List<Transaction> getTransactionList()
    {
        return sortTransactionsByDate(transactionList);
    }

    // Method to sort transactions by a given month and year into a list
    public List<Transaction> getTransactionsByMonthAndYear(int month, int year)
    {
        List<Transaction> filteredTransactions = new List<Transaction>();
        foreach (Transaction transaction in transactionList)
        {
            if (transaction.Date.Month == month && transaction.Date.Year == year)
            {
                filteredTransactions.Add(transaction);
            }
        }
        return sortTransactionsByDate(filteredTransactions);
    }

    // Method to sort transactions by a given category into a list
    public List<Transaction> getTransactionsByCategory(string category)
    {
        List<Transaction> filteredTransactions = new List<Transaction>();
        foreach (Transaction transaction in transactionList)
        {
            if (transaction.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            {
                filteredTransactions.Add(transaction);
            }
        }
        return sortTransactionsByDate(filteredTransactions);
    }

    // Method to sort transactions by a given category and month/year into a list
    public List<Transaction> getTransactionsByCategoryAndMonthAndYear(string category, int month, int year)
    {
        List<Transaction> filteredTransactions = new List<Transaction>();
        foreach (Transaction transaction in transactionList)
        {
            if (transaction.Category.Equals(category, StringComparison.OrdinalIgnoreCase) &&
                transaction.Date.Month == month && transaction.Date.Year == year)
            {
                filteredTransactions.Add(transaction);
            }
        }
        return sortTransactionsByDate(filteredTransactions);
    }
}