Sometime the db will not connect properly. 

First of all make sure that you have installed sql lite correctly.

If you get an error for namespace name 'SQLite' doesn't exist in the namespace 'System.Data' then you must install it with this:

    dotnet add package System.Data.SQLite

Now run:

    dotnet build;
    dotnet run

And it should work. This was the error I had with Week 3 Northwind exercises creating the CRUD functionality in the singular file as i previously installed SQLite individually on project initialisation. But when i returned and wanted to consolidate it to one, i had an issue as SQLite wasn't being picked up.
