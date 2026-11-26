public class Controller
{
    public void Run()
    {
        Console.WriteLine("Controller is running.");
        
        UserInterface userInterface = new UserInterface();
        TransactionLog transactionLog = new TransactionLog();
        TransactionLogAnalyzer analyzer = new TransactionLogAnalyzer();

        userInterface.Start();
    }
}