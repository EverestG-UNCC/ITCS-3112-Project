// UserInterface.cs
// This class represents the user interface for the application.
// It Implements the front end of the application, allowing users to interact with the system through a console-based interface.

public class UserInterface
{
    // Instance variable to hold a reference to the controller
    private Controller controller;

    // Constructor that gives the UI a reference to the controller
    public UserInterface(Controller controller)
    {
        this.controller = controller;
    }

    // Define the options available to the user
    string[] options = new string[]
    {
        "type '0' to quit the application.", 
        "type '1' to print the transaction log.",
        "type '2' to manage transactions.",
        "type '3' to get transaction statistics.",
        "type '4' to add sample data to the transaction log."
    };

    // Define the printing options available to the user
    string[] printOptions = new string[]
    {
        "type '0' to go back to the main menu.",
        "type '1' to print all transactions.",
        "type '2' to print transactions by month and year.",
        "type '3' to print transactions by category.",
        "type '4' to print transactions by category and month/year."
    };

    // Define the transaction management options available to the user
    string[] manageOptions = new string[]
    {
        "type '0' to go back to the main menu.",
        "type '1' to create a new transaction.",
        "type '2' to get and view a transaction by ID.",
        "type '3' to remove a transaction by ID."
    };

    // Method to start the user interface and handle user input
    public void Start()
    {
        Console.WriteLine("User Interface is starting.");

        // Main loop to continuously display options and read user input
        while (true)
        {
            Console.Clear(); // Clear the console for a fresh display

            DisplayOptions(options); // Display the options to the user

            String? input = ReadUserInput(); // Read the user input

            if (MakeMainDecision(input)) // Make a decision based on the user input
            {
                break; // Exit the loop and end the program
            } 
        }


    }

    // Helper method to display the options to the user
    private void DisplayOptions(string[] options)
    {
        Console.WriteLine("Please choose an option:");

        // Iterate and print options
        foreach (String option in options)
        {
            Console.WriteLine(option);
        }
    }

    // Abstraction method to ask the user to press any key to continue
    private void PressAnyKeyToContinue()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(intercept: true);
    }

    // Helper method to read the user input and return it as a string
    private string? ReadUserInput()
    {
        return Console.ReadLine();
    }

    // Helper method to get a month and year from the user and return them as a tuple
    private (int month, int year) GetMonthAndYearFromUser()
    {
        Console.WriteLine("Please enter the month (1-12):");
        int month = int.Parse(ReadUserInput() ?? "0"); // Read the month input

        Console.WriteLine("Please enter the year (e.g., 2023):");
        int year = int.Parse(ReadUserInput() ?? "0"); // Read the year input

        return (month, year); // Return the month and year as a tuple
    }

    // Helper method to get a category from the user and return it as a string
    private string GetCategoryFromUser()
    {
        Console.WriteLine("Please enter the category (e.g., Food, Transportation, etc.):");
        return (ReadUserInput() ?? "").ToLower().Replace(" ", ""); // Read the category input
    }

    // Helper method to get a transaction ID from the user
    private int GetTransactionIdFromUser()
    {
        Console.WriteLine("Please enter the transaction ID:");
        return int.Parse(ReadUserInput() ?? "0"); // Read the transaction ID input
    }

    // Helper method to get transaction input from the user
    private (string category, DateTime date, float amount, string vendor) GetTransactionInputFromUser()
    {
        Console.WriteLine("Please enter the category:");
        string category = ReadUserInput() ?? ""; // Read the category input

        Console.WriteLine("Please enter the date (MM/DD/YYYY):");
        DateTime date = DateTime.Parse(ReadUserInput() ?? ""); // Read the date input

        Console.WriteLine("Please enter the amount:");
        float amount = float.Parse(ReadUserInput() ?? "0.00"); // Read the amount input

        Console.WriteLine("Please enter the vendor:");
        string vendor = ReadUserInput() ?? ""; // Read the vendor input

        return (category, date, amount, vendor); // Return the transaction input as a tuple
    }

    // Helper method to cleanly print transactions from a list of transactions
    private void PrintTransactions(List<Transaction> transactions)
    {
        foreach (Transaction transaction in transactions)
        {
            PrintTransaction(transaction); // Print each transaction using the PrintTransaction helper method
        }
    }

    // Helper method to cleanly print a transaction
    private void PrintTransaction(Transaction transaction)
    {
        Console.WriteLine(
            $"ID: {transaction.Id}, " + 
            $"$: {transaction.Amount}, " + 
            $"Category: {transaction.Category}, " + 
            $"Date: {transaction.Date.ToShortDateString()}, " + 
            $"Vendor: {transaction.Vendor}"
        );
    }

    // Helper method to read the user input and make decisions
    private bool MakeMainDecision(string? input)
    {
        if (input == "0") // Exit the application
        {
            Console.WriteLine("Exiting the application.");
            return true; // Return true to indicate that the application should exit
        }
        else if (input == "1") // Offer printing options to the user
        {
            Console.Clear(); // Clear the console for a fresh display

            DisplayOptions(printOptions); // Display the printing options to the user

            String? printInput = ReadUserInput(); // Read the user input for printing options

            MakePrintDecision(printInput); // Make a decision based on the printing option input
        }
        else if (input == "2") // Offer transaction management options to the user
        {
            Console.Clear(); // Clear the console for a fresh display
            
            DisplayOptions(manageOptions); // Display the transaction management options to the user

            String? manageInput = ReadUserInput(); // Read the user input for transaction management options

            MakeManageDecision(manageInput); // Make a decision based on the transaction management option input
        }
        else if (input == "3") // Offer transaction statistics options to the user
        {
            Console.Clear(); // Clear the console for a fresh display
            Console.WriteLine("Getting transaction statistics...");
        }
        else if (input == "4") // Offer to add sample data to the transaction log
        {
            Console.Clear(); // Clear the console for a fresh display

            Console.WriteLine("Adding sample data to the transaction log...");

            controller.CAddSampleData(); // Call the controller method to add sample data to the transaction log
            PressAnyKeyToContinue(); // Let the user read the message before returning to the main menu
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again."); // Retry
            PressAnyKeyToContinue();
        }
        return false; // Return false to indicate that the application should continue
    }

    // Helper method to read the user input and make decisions for printing options
    private void MakePrintDecision(string? input)
    {
        if (input == "0")
        {
            return; // Return to the main menu
        }
        else if (input == "1") // Print all transactions
        {
            List<Transaction> transactions = controller.CGetTransactionList(); // Call the controller method to get the transaction list
            PrintTransactions(transactions); // Print the transactions
        }
        else if (input == "2") // Print transactions by month and year
        {
            (int month, int year) = GetMonthAndYearFromUser();
            List<Transaction> transactions = controller.CGetTransactionsByMonthAndYear(month, year); // Call the controller method to get the transaction list
            PrintTransactions(transactions); // Print the transactions
        }
        else if (input == "3") // Print transactions by category
        {
            string category = GetCategoryFromUser();
            List<Transaction> transactions = controller.CGetTransactionsByCategory(category); // Call the controller method to get the transaction list
            PrintTransactions(transactions); // Print the transactions
        }
        else if (input == "4") // Print transactions by category and month/year
        {
            String category = GetCategoryFromUser();
            (int month, int year) = GetMonthAndYearFromUser();
            List<Transaction> transactions = controller.CGetTransactionsByCategoryAndMonthAndYear(category, month, year); // Call the controller method to get the transaction list
            PrintTransactions(transactions); // Print the transactions
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
            PressAnyKeyToContinue();
        }
        PressAnyKeyToContinue(); // Let the user read the message before returning to the main menu
    }

    // Helper method to read the user input and make decisions for transaction management options
    private void MakeManageDecision(string? input)
    {
        if (input == "0")
        {
            return; // Return to the main menu
        }
        else if (input == "1") // Create a new transaction
        {
            (string category, DateTime date, float amount, string vendor) = GetTransactionInputFromUser();

            controller.CCreateTransaction(category, date, amount, vendor); // Call the controller method to create a new transaction
            Console.WriteLine("Transaction created successfully.");
        }
        else if (input == "2") // Get and view a transaction by ID
        {
            int id = GetTransactionIdFromUser();

            Transaction? transaction = controller.CGetTransactionById(id); // Call the controller method to get the transaction by ID
            if (transaction == null)
            {
                Console.WriteLine("Transaction not found.");
            }
            else
            {
                PrintTransaction(transaction); // Print the transaction using the PrintTransaction helper method
            }
        }
        else if (input == "3") // Remove a transaction by ID
        {
            int id = GetTransactionIdFromUser();

            bool isRemoved = controller.CRemoveTransactionById(id); // Call the controller method to remove the transaction by ID

            if (isRemoved)
            {
                Console.WriteLine("Transaction removed successfully.");
            }
            else
            {
                Console.WriteLine("Transaction not found.");
            }
        }
        PressAnyKeyToContinue(); // Let the user read the message before returning to the main menu
    }
}