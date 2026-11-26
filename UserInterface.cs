public class UserInterface
{
    public void Start()
    {
        Console.WriteLine("User Interface is starting.");

        string[] options = new string[]
        {
            "type '0' to quit the application.", 
            "type '1' to print the transaction log.",
            "type '2' to get transaction statistics."
        };

        while (true)
        {
            Console.Clear();
            
            DisplayOptions(options);

            String? input = Console.ReadLine();
            if (input == "0")
            {
                Console.WriteLine("Exiting the application.");
                break;
            }
            else if (input == "1")
            {
                Console.WriteLine("Printing the transaction log...");
                // Logic to print the transaction log
            }
            else if (input == "2")
            {
                Console.WriteLine("Getting transaction statistics...");
                // Logic to get transaction statistics
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(intercept: true);
            }
        }


    }

    // Helper method to display the options to the user
    private void DisplayOptions(string[] options)
    {
        Console.WriteLine("Please choose an option:");
        foreach (String option in options)
        {
            Console.WriteLine(option);
        }
    }
}