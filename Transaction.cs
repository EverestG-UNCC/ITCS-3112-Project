// This class represents a financial transaction in the application.
// Each transaction contains information about itself, such as the category, date, amount, and vendor.
// The Transaction class also has a unique ID for each transaction, which is automatically generated upon creation.

public class Transaction
{
    // Instance variables of the Transaction class
    public string Category;
    public DateTime Date;
    public float Amount;
    public string Vendor;
    public int Id;
    public static int IdCounter = 0;

    // Constructor for the Transaction class
    public Transaction(string category, DateTime date, float amount, string vendor)
    {
        Category = category;
        Date = date;
        Amount = amount;
        Vendor = vendor;
        Id = ++IdCounter;
    }
}