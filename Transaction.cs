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