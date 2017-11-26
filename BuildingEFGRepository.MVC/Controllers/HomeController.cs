using BuildingEFGRepository.DAL;
using BuildingEFGRepository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingEFGRepository.MVC.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IDisconGenericRepository<FootballClub> repository)
        {

            //using(var context = new MyDBEntities())
            //{
            //    var data2 = context.Cities.ToList();
            //}


            //var data = repository.All().ToList();


        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}