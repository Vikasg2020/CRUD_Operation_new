using CRUD_Operation.DB_Entity;
using CRUD_Operation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operation.Controllers
{
    public class AddEmpController : Controller
    {
        // GET: AddEmp

        [HttpGet]
        public ActionResult AddEmpDetail()
        {


            return View();
        }

        [HttpPost]
        public ActionResult AddEmpDetail(EmpModel em)
        {
            EmpEntities ee = new EmpEntities();

            EmpDetail ed = new EmpDetail();

            ed.id = em.id;
            ed.name = em.name;
            ed.sal = em.sal;
            ed.dep = em.dep;

            if (em.id == 0)
            {

                ee.EmpDetails.Add(ed);
                ee.SaveChanges();      
            }
            else
            {
                ee.Entry(ed).State = System.Data.Entity.EntityState.Modified;
                ee.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult EmpEdit(int id)
        {
            EmpEntities ee = new EmpEntities();
            var re = ee.EmpDetails.Where(x => x.id == id).First();

            EmpModel emd = new EmpModel();

            emd.id = re.id;
            emd.name = re.name;
            emd.sal = re.sal;
            emd.dep = re.dep;

            ViewBag.id = re.id;

            return View("AddEmpDetail", emd);
        }

        
    }
}