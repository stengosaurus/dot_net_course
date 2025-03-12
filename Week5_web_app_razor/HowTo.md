## How to Create a Project and Initialize a Razor Web App

1. Create the Web App Project with this command:
    dotnet new razor --name WebApp

    // This creates the Razor Pages web appliction inside WebApp
    // The default structure includes Program.cs, Startup.cs, Pages/ and other necessary files

2. cd into this directory:
    cd WebApp

3. Add the Required Dependencies:
    3.1 Install Entity Framework Core for SQLite
        dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    3.1 Install Entity Framework Core Tools (Optional, but usefull for db migrations)
        dotnet tool install --global dotnet-ef

4. Set up the Database (Films.db)
    4.1. Copy the Films.sql file into the WebApp directory
    4.2. Create the Films.db file using:
        sqlite3 Films.db < Films.sql
    4.3. Verify the db was created:
        sqlite3 Films.db
        .tables
        
        // you should see Films and Actors tables listed
        // ctrl+D will exit sqlite3 console app

5. Set Up Entity Framework Context and Models
    5.1 Create a FilmEntities.cs file
    5.2 Create a FilmContext.cs file

    // Paste in the relavent data for each file

6. Modify Program.cs
    6.1 Open Program.cs and add its contents

7. Create a Startup.cs
    7.1 Open Startup.cs and add its contents

8. Configure the Razor Pages
    8.1 Modify Pages/Index.cshtml.cs by adding its contents
    8.2 Modify Pages/Index.cshtml by adding its contents
    8.3 Add Pages/Insert.cshtml by adding its contents
    8.4 Add Pages/Insert.cshtml.cs by adding its contents
    8.5 Add Pages/Delete.cshtml by adding its contents
    8.6 Add Pages/Delete.cshtml.cs by adding its contents


9. This should now work if we build and run.
10. If you get a security warning in the browser, run:
    dotnet dev-certs https --trust
// Trust ASP.NET Core HTTPS Development Certificate


OPTIONAL steps:

1. Create a second page:
    touch Movies.cshtml && Movies.cshtml.cs
    // Add the following code

2. Add a Nav Link to connect to this new page
    edit the _Layout.cshtml file to include an a tag linking to this page