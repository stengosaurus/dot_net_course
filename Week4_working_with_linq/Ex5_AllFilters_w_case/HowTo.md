## All Filtering with Case Statement

Consolidated Filtering Console Application for the Northwind Database

This exercise consolidates all previous filtering exercises into a single interactive console application. The user selects filtering options from a menu.

## Steps:

1. Create new directory for file:
    mkdir NameOfApp
    cd NameOfApp
2. Init new dotnet project:
    dotnet new console
3. Add the db file to the directory.
4. Install SQLite with this command:
    dotnet add package System.Data.SQLite
5. Connect to the Northwind.db database in Program.cs
6. Add a case statement with options for each filtering function needed.
7. Create these functions.
8. Build and run with:
    dotnet build
    dotnet run


# ################################################# #


> Feature Details

View Product IDs, Names, and Supplier Names

Display Products and their Suppliers

This feature retrieves Product IDs, Product Names, and Supplier Names by joining the Products and Suppliers tables.

Results are displayed in order of Product ID.



> Filter Customers by Country

Display Customers in a Selected Country

The user is prompted to enter a country name.
The program queries the Customers table to retrieve all customers from the given country.
Results are displayed in alphabetical order.
Example Countries

USA
Germany
France
Brazil
Canada



> Filter Products by Price Range

Display Products Within a Price Range

The user is prompted to enter a minimum price and a maximum price.
The program retrieves all products whose price falls within this range.
Results are displayed in ascending order of price.



> Filter Products by Category

Display Products by Category Name

The user is prompted to enter a category name.
The program retrieves all products belonging to the entered category.
Results are displayed in alphabetical order.