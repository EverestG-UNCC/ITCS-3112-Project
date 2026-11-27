# ITCS-3112-Project

A console application for creating, editing and viewing a transaction log and transaction statistics.

## Prerequisites

- Git
- The .NET 11 SDK. This project targets `net11.0`, so the SDK is required; installing only the .NET runtime is not sufficient.

Install the SDK from the [official .NET downloads page](https://dotnet.microsoft.com/download/dotnet/11.0). To verify the installation, open a terminal and run:

```sh
dotnet --version
```

The reported SDK version should be `11.x` or later with support for the `net11.0` target.

## Clone and run

Clone the repository and change into its directory:

```sh
git clone https://github.com/EverestG-UNCC/ITCS-3112-Project.git
cd ITCS-3112-Project
```

Make sure to run the clear command in your terminal before using, as a cluttered terminal may not be fully cleared effectively by the program.

```sh
clear
```

Make sure to input valid data during use, as invalid data may crash the application.

Run the application from the directory containing `ITCS-3112-Project.csproj`:

```sh
dotnet run
```

`dotnet run` restores dependencies and builds the project automatically before starting it. Run it in an interactive terminal so you can enter menu choices and respond to keypress prompts.

## Using the application

Follow the menu prompts in the terminal:

- Enter `0` to quit.
- Enter `1` to print the transaction log.
- Enter `2` to manage transactions.
- Enter `3` to get transaction statistics. 
- Enter `4` to add sample data to the transaction log.
