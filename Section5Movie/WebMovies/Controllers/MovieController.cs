using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Triogole.Sql;
using Movie;
using System.Configuration;
using WebMovies.Models; 

namespace WebMovies.Controllers
{
    [DescriptionAttribute("Handles Mvoie requests")]
    public class MovieController : Controller
    {
        public MovieController() : this(GetDatabase())
        {
        }

        public MovieController(IMovieDatabase database)
        {
            _database = database;
        }


        public ActionResult Add()
        {
            var model = new MovieViewModels();

            return View(model);
        }

        [HttpPost]

        public ActionResult Add(MovieViewModels model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Add(model.ToDomain());

                    return RedirectToAction("List");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var title = _database.Get(id);
            if (title == null)
                return HttpNotFound();

            return View(title.ToModel());
        }

        [HttpPost]
        public ActionResult Delete(MovieViewModels model)
        {
            try
            {
                _database.Remove(model.Id);

                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var title = _database.Get(id);
            if (title == null)
                return HttpNotFound();

#pragma warning disable CS0618 // Type or member is obsolete
            var value = title.CalculatedProperty;
#pragma warning restore CS0618 // Type or member is obsolete

            return View(title.ToModel());
        }

        public ActionResult Edit(MovieViewModels model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _database.Update(model.ToDomain());

                    return RedirectToAction("List");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            }

            return View(model);
        }
        // GET: Movie
        public ActionResult List()
        {
            var titles = _database.GetAll();

            return View(titles.ToModel());
        }

        private static IMovieDatabase GetDatabase()
        {
            var connstring = ConfigurationManager.ConnectionStrings["MovieDatabase"];

            return new SqlTitleDatabase(connstring.ConnectionString);
        }

        private readonly IMovieDatabase _database;
    }
}