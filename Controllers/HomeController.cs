using CoronaManagment.BL;
using CoronaManagment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoronaManagment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult UpdateAndWach()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetInsurees()
        {
            var insurees = BusinessLogic.GetInsurees();
            return Json(insurees);

        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            BusinessLogic.Delete(id);
            var insurees = BusinessLogic.GetInsurees();
            return Json(insurees);
        }

        [HttpPost]
        public JsonResult AddInsured(Insured insured)
        {
            BusinessLogic.AddInsured(insured);
            var insurees = BusinessLogic.GetInsurees();
            return Json(insurees);
        }

        [HttpPost]
        public JsonResult UpdateInsured(Insured insured)
        {
            BusinessLogic.UpdateInsured(insured);
            var insurees = BusinessLogic.GetInsurees();
            return Json(insurees);
        }

        [HttpPost]
        public JsonResult AddVacine(Vacine vacine)
        {
            BusinessLogic.AddVacine(vacine);
            var vacineUpdate = BusinessLogic.getVacineByInsuredId(vacine.InsuredID);
            return Json(vacineUpdate);
            
        }

        [HttpPost]
        public JsonResult getInsuredInform(string id)
        {
            var insured = BusinessLogic.getInsuredInform(id);
            return Json(insured);
        }
    }
}