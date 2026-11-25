using System.Transactions;

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
    public void createTransaction(string category, DateTime date, float amount, string vendor, int id)
    {
        Transaction newTransaction = new Transaction(category, date, amount, vendor, id);
        transactionList.Add(newTransaction);
    }

    // Getter method to retrieve a transaction by its ID
    public Transaction getTransactionById(int id)
    {
        return transactionList.get(id);
    }

    // Method to remove a transaction from the list by its ID
    public bool removeTransactionById(int id)
    {
        return transactionList.Remove(id);
    }


    // Getter method to retrieve the list of transactions
    public List<Transaction> getTransactionList()
    {
        return transactionList;
    }
}