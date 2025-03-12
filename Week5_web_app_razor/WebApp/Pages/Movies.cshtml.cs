using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FilmEntities;
using FilmContext;

namespace WebApp.Pages
{
    public class ViewMovies : PageModel
    {
        public List<FilmActor> Films { get; set; }

        public void OnGet()
        {
            using (var db = new FilmsDatabase())
            {
                Films = db.Films
                    .Join(db.Actors,
                        f => f.ActorID,
                        a => a.ActorID,
                        (f, a) => new FilmActor
                        {
                            FilmID = f.FilmID,
                            Title = f.Title,
                            Year = f.Year,
                            Firstname = a.Firstname,
                            Lastname = a.Lastname
                        })
                    .ToList();
            }
        }
    }
}
