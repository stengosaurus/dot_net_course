## Here we explain how the JamesBond_FilmsDB project works.

>> Using (Entity Framework Core + SQLite)


## Introduction:

The project is structured to use Entity Framework Core (EF Core) with SQLite to manage a database of films and actors. It consists of:

    1. Program.cs – The main console application, handling user interaction through a menu and performing CRUD operations.

    2. FilmContext.cs – Defines the database context (FilmsDatabase) that connects to the SQLite database and maps to the Films and Actors tables.

    3. FilmEntities.cs – Defines C# classes (Film, Actor, FilmActor) that represent the database tables.

    4. Films.db – The SQLite database file containing Films and Actors tables.

    5. .csproj file – Configures the project and includes the EF Core SQLite package.

--------------------------------------------------------------------------------------


# How to Set up and Run

1. Create the directory and cd into it
2. Create the dotnet app:
    dotnet new console
3. Install Entity Framework Core SQLite
    if you havent alreadym install the required NuGet package:

        dotnet add package Microsoft.EntityFrameworkCore.Sqlite
4. Add the Films.sql file into the directory
5. Create the Films.db file by runningL
    sqlite3 Films.db < Films.sql
6. Verify that the db was created successfully by runningL
    sqlite3 Films.db
7. Once inside we can run:
    .tables
    This should show us Actors Films etc...
8. Create the FilmEntities.cs
    touch FilmEntities.cs
9. Add this data to FilmEntities.cs

namespace FilmEntities;

public class Film
{
    public int FilmID { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int ActorID { get; set; } // Foreign Key linking to Actors
}

public class Actor
{
    public int ActorID { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}

public class FilmActor
{
    public int FilmID { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int ActorID { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}

10. Create the FilmContext.cs file:
    touch FilmContext.cs
11. Add this data to FilmContext.cs
using Microsoft.EntityFrameworkCore;
using FilmEntities;

namespace FilmContext
{
    public class FilmsDatabase : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Films.db");
        }
    }
}

12. Modify Program.cs to use the database. Make sure it is using FilmsDatabase
13. Disable Nullable in .csproj (if needed)
    Edit the .csproj file and comment out Nullable:
    <!-- <Nullable>enable</Nullable> -->
    This prevents warnings/errors about null values in your entity classes
14. Build and Run


--------------------------------------------------------------------------------------






## Understanding the Components


## 1. FilmEntities.cs 

(Defining the Database Model)
This file defines the structure of database tables using C# classes.

public class Film
{
    public Int32 FilmID { get; set; }
    public String Title { get; set; }
    public Int32 Year { get; set; }
    public Int32 ActorID { get; set; } // Foreign Key to link to Actor
}

>> Why do we need it?
Entity Framework Core uses Code-First approach to map C# classes to database tables.

    1. Film class maps to the Films table.
    2. Actor class maps to the Actors table.
    3. FilmActor is a custom class used to represent a JOIN between Films and Actors.


> Each film has an ActorID field, linking it to the Actors table.

--------------------------------------------------------------------------------------
## 2. FilmContext.cs 

(Database Context)
This file defines how EF Core interacts with the database.

public class FilmsDatabase : DbContext
{
    public DbSet<Film> Films { get; set; }
    public DbSet<Actor> Actors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=Films.db");
    }
}

> Why do we need it?

1. Extends DbContext → EF Core uses this to interact with the database.
2. DbSet<Film> & DbSet<Actor> → EF Core tracks these entities in the database.
3. UseSqlite("Filename=Films.db") → Connects to the Films.db SQLite database.

--------------------------------------------------------------------------------------

## Program.cs

(Main Application)
This is the console app where users interact with the database.


Key Features
    1. Switch case menu to allow user input.
    2. CRUD operations (Create, Read, Update, Delete) using Entity Framework.
    3. Uses LINQ (.Where(), .OrderBy(), .Join()) to interact with the database.


Example:

static void ReadFilms()
{
    List<Film> films = db.Films.ToList();
    Console.WriteLine("\nList of Films:");
    foreach (Film film in films)
    {
        Console.WriteLine($"{film.FilmID}. {film.Title} ({film.Year})");
    }
}

> This fetches all films from the database and displays them.

--------------------------------------------------------------------------------------

How Does EF Core Work?

Database First vs Code First
You're using Code First in this project, meaning:

    1. C# Classes (Film, Actor) define the database schema.
    2. EF Core uses DbContext (FilmsDatabase.cs) to manage database operations.
    3. If you want to generate the database from C# classes, you would use Migrations (discussed later).

--------------------------------------------------------------------------------------