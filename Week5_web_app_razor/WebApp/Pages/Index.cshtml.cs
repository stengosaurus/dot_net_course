using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using FilmEntities;
using FilmContext;

namespace WebApp.Pages
{
    public class ViewActors : PageModel
    {
        public String Heading { get; set; }
        public List<Actor> Actors { get; set; }

        public void OnGet()
        {
            Heading = "James Bond Actors";

            FilmsDatabase db = new FilmsDatabase();
            Actors = db.Actors.ToList();
        }
    }
}
