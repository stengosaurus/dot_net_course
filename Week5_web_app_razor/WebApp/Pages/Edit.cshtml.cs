using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FilmEntities;
using FilmContext;

namespace WebApp.Pages
{
    public class EditActor : PageModel
    {
        public Actor Actor { get; set; }

        public void OnGet()
        {
            int actorID = Int32.Parse(Request.Query["hdnActorID"]);
            FilmsDatabase db = new FilmsDatabase();
            Actor = db.Actors.SingleOrDefault(a => a.ActorID == actorID);
        }

        public IActionResult OnPost()
        {
            int actorID = Int32.Parse(Request.Form["hdnActorID"]);
            string firstName = Request.Form["tbxFirstname"];
            string lastName = Request.Form["tbxLastname"];

            FilmsDatabase db = new FilmsDatabase();
            Actor actor = db.Actors.SingleOrDefault(a => a.ActorID == actorID);
            
            if (actor != null)
            {
                actor.Firstname = firstName;
                actor.Lastname = lastName;
                db.SaveChanges();
            }

            return Redirect("~/Index");
        }
    }
}
