## Filtering by Price

Display Products Within a Price Range

This exercise prompts the user to enter a minimum price and a maximum price. It then retrieves all products whose price falls within the given range and displays them in ascending order of price.

Steps:

1. Install SQLite with this command:
    dotnet add package System.Data.SQLite
2. Connect to the Northwind.db database.
3. Prompt the user for a minimum and maximum price.
4. Query the Products table for all products within that price range.
5. Display the results ordered by price (ascending).