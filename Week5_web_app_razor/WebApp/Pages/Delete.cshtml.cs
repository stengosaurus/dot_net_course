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
    public class DeleteActor : PageModel
    {
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            // Actor insActor = new Actor() {
            //     Firstname = Request.Form["tbxFirstname"],
            //     Lastname = Request.Form["tbxLastname"],
            // };
            // FilmsDatabase db = new FilmsDatabase();
            // db.Actors.Add(insActor);
            // db.SaveChanges();

            FilmsDatabase db = new FilmsDatabase();
            Actor delActor = db.Actors.Single(a => a.ActorID == Int32.Parse(Request.Form["hdnActorID"]));
            db.Actors.Remove(delActor);
            db.SaveChanges();

            return Redirect("~/Index");
        }
    }
}
