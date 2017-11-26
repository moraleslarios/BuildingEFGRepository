using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuildingEFGRepository.DataBase;
using BuildingEFGRepository.DAL;

namespace BuildingEFGRepository.MVC.Controllers
{
    public class FootballClubsController : Controller
    {
        private readonly IDisconGenericRepository<FootballClub> _repository;


        public FootballClubsController(IDisconGenericRepository<FootballClub> repository)
        {
            _repository = repository;
        }



        // GET: FootballClubs
        public ActionResult Index()
        {
            var model = _repository.All();

            return View(model);
        }

        // GET: FootballClubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootballClub footballClub = _repository.Find(id);
            if (footballClub == null)
            {
                return HttpNotFound();
            }
            return View(footballClub);
        }

        // GET: FootballClubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FootballClubs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CityId,Name,Members,Stadium,FundationDate,Logo")] FootballClub footballClub)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(footballClub);
                return RedirectToAction("Index");
            }

            return View(footballClub);
        }

        // GET: FootballClubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            FootballClub footballClub = _repository.Find(id);

            if (footballClub == null) return HttpNotFound();

            return View(footballClub);
        }

        // POST: FootballClubs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CityId,Name,Members,Stadium,FundationDate,Logo")] FootballClub footballClub)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(footballClub);

                return RedirectToAction("Index");
            }
            return View(footballClub);
        }

        // GET: FootballClubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootballClub footballClub = _repository.Find(id);
            if (footballClub == null)
            {
                return HttpNotFound();
            }
            return View(footballClub);
        }

        // POST: FootballClubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Remove(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) => base.Dispose(disposing);
    }
}
