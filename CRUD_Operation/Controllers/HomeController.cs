using CRUD_Operation.DB_Entity;
using CRUD_Operation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmpEntities ee = new EmpEntities();

            var re = ee.EmpDetails.ToList();

           List< EmpModel> em = new List<EmpModel>();

            foreach(var item in re)
            {
                em.Add(new EmpModel
                {
                    id = item.id,
                    name = item.name,
                    sal = item.sal,
                    dep = item.dep
                });
            }



            return View(em);
        }

       


        

        public ActionResult empDelete(int id)
        {
            EmpEntities ee = new EmpEntities();
            var dele = ee.EmpDetails.Where(x => x.id == id).First();
            ee.EmpDetails.Remove(dele);
            ee.SaveChanges();
            return RedirectToAction("Index","Home");
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