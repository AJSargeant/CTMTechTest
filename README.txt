CTMTechTest README

This Project was built on Windows 10 using Visual Studio 2017
The project was run using IIS Express on the development machine.

The project uses a local SQLLite database.
In order to create this database before running the project, do the following:

Open the project in Visual Studio
Open: Tools > NuGet Package Manager > Package Manager Console
Run the command: update-database

This will execute the migration script and build the database.


Transactions were added to the project during development using JSON.
The JSON objects were added using Postman in the format:
{
    "description" : "Here goes the description for the transaction"
}
JSON objects were sent to the address "CTMTechTest/api/TransactionAPI"