using System;
using System.Collections.Generic;
using System.Linq;
using FilmEntities;
using FilmContext;
using Microsoft.EntityFrameworkCore;

class Program
{
    static FilmsDatabase db = new FilmsDatabase();

    static void Main(string[] args)
    {
        Console.WriteLine("Film Database Management!");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. View all films");
            Console.WriteLine("2. View all actors");
            Console.WriteLine("3. View all film actors");
            Console.WriteLine("4. View all film actors ordered");
            Console.WriteLine("5. View all film titles");
            Console.WriteLine("6. Filtered by year");
            Console.WriteLine("7. Add a new film");
            Console.WriteLine("8. Select a film by ID");
            Console.WriteLine("9. Update a film");
            Console.WriteLine("10. Delete a film");
            Console.WriteLine("11. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ReadFilms();
                    break;
                case "2":
                    ReadActors();
                    break;
                case "3":
                    ReadFilmActors();
                    break;
                case "4":
                    ReadActorsOrdered();
                    break;
                case "5":
                    ReadFilmTitles();
                    break;
                case "6":
                    FilteredYear();
                    break;
                case "7":
                    CreateFilm();
                    break;
                case "8":
                    SelectFilm();
                    break;
                case "9":
                    UpdateFilm();
                    break;
                case "10":
                    DeleteFilm();
                    break;
                case "11":
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    // READ FILMS
    static void ReadFilms()
    {
        List<Film> films = db.Films.ToList();
        Console.WriteLine("\nList of Films:");
        foreach (Film film in films)
        {
            Console.WriteLine($"{film.FilmID}. {film.Title} ({film.Year})");
        }
    }

    // READ ACTORS
    static void ReadActors()
    {
        List<Actor> actors = db.Actors.ToList();
        Console.WriteLine("\nList of Actors:");
        foreach (Actor actor in actors)
        {
            Console.WriteLine($"{actor.ActorID}. {actor.Firstname} {actor.Lastname}");
        }
    }

    // READ FILM ACTORS
    static void ReadFilmActors()
    {
        var filmActors = db.Films.Join(db.Actors,
            f => f.ActorID, a => a.ActorID,
            (f, a) => new FilmActor
            {
                FilmID = f.FilmID,
                Title = f.Title,
                Year = f.Year,
                ActorID = a.ActorID,
                Firstname = a.Firstname,
                Lastname = a.Lastname
            }).ToList();

        Console.WriteLine("\nList of Film Actors:");
        foreach (var filmActor in filmActors)
        {
            Console.WriteLine($"{filmActor.FilmID}. {filmActor.Title} ({filmActor.Year}) - {filmActor.ActorID} {filmActor.Firstname} {filmActor.Lastname}");
        }
    }

    // READ ACTORS ORDERED
    static void ReadActorsOrdered()
    {
        var actorsOrdered = db.Actors.OrderBy(a => a.Firstname).ToList();
        Console.WriteLine("\nList of Actors Ordered:");
        foreach (var actor in actorsOrdered)
        {
            Console.WriteLine($"{actor.ActorID}. {actor.Firstname} {actor.Lastname}");
        }
    }

    // READ FILM TITLES
    static void ReadFilmTitles()
    {
        var titles = db.Films.Select(f => f.Title).ToList();
        Console.WriteLine("\nList of Film Titles:");
        foreach (var title in titles)
        {
            Console.WriteLine(title);
        }
    }

    // FILTERED YEAR
    static void FilteredYear()
    {
        Console.Write("\nEnter a start year: ");
        Int32 startYear = Int32.Parse(Console.ReadLine());
        Console.Write("Enter an end year: ");
        Int32 endYear = Int32.Parse(Console.ReadLine());

        var filteredFilms = db.Films
            .Where(f => f.Year >= startYear && f.Year <= endYear)
            .ToList();

        Console.WriteLine("\nFiltered Films:");
        foreach (var film in filteredFilms)
        {
            Console.WriteLine($"{film.Title} ({film.Year})");
        }
    }

    // CREATE FILM
    static void CreateFilm()
    {
        Console.Write("\nEnter the title of the film: ");
        string title = Console.ReadLine();
        Console.Write("Enter the year of the film: ");
        Int32 year = Int32.Parse(Console.ReadLine());

        var newFilm = new Film { Title = title, Year = year };
        db.Films.Add(newFilm);
        db.SaveChanges();

        Console.WriteLine("Film added successfully!");
    }

    // SELECT FILM
    static void SelectFilm()
    {
        Console.Write("\nEnter a film ID: ");
        Int32 filmID = Int32.Parse(Console.ReadLine());

        var film = db.Films.SingleOrDefault(f => f.FilmID == filmID);
        if (film != null)
        {
            Console.WriteLine($"Film ID: {film.FilmID}, Title: {film.Title}, Year: {film.Year}");
        }
        else
        {
            Console.WriteLine("Film not found.");
        }
    }

    // UPDATE FILM
    static void UpdateFilm()
    {
        Console.Write("\nEnter a film ID to update: ");
        Int32 filmID = Int32.Parse(Console.ReadLine());

        var film = db.Films.SingleOrDefault(f => f.FilmID == filmID);
        if (film != null)
        {
            Console.Write("Enter an updated title: ");
            film.Title = Console.ReadLine();
            Console.Write("Enter an updated year: ");
            film.Year = Int32.Parse(Console.ReadLine());

            db.SaveChanges();
            Console.WriteLine("Film updated successfully!");
        }
        else
        {
            Console.WriteLine("Film not found.");
        }
    }

    // DELETE FILM
    static void DeleteFilm()
    {
        Console.Write("\nEnter the ID of the film to delete: ");
        Int32 filmID = Int32.Parse(Console.ReadLine());

        var film = db.Films.SingleOrDefault(f => f.FilmID == filmID);
        if (film != null)
        {
            db.Films.Remove(film);
            db.SaveChanges();
            Console.WriteLine("Film deleted successfully!");
        }
        else
        {
            Console.WriteLine("Film not found.");
        }
    }
}
