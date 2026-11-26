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
    public void createTransaction(string category, DateTime date, float amount, string vendor)
    {
        Transaction newTransaction = new Transaction(category, date, amount, vendor);
        transactionList.Add(newTransaction);
    }

    // Getter method to retrieve a transaction by its ID
    public Transaction? getTransactionById(int id)
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


    // Getter method to retrieve the list of transactions
    public List<Transaction> getTransactionList()
    {
        return transactionList;
    }
}