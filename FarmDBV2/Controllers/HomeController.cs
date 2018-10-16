using FarmDBV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmDBV2.Controllers
{
    public class HomeController : Controller
    {
        private Models.FarmDBEntities2 db = new Models.FarmDBEntities2();
        public ActionResult Index()
        {
            int year = DateTime.Today.Year-1;
            ViewBag.firstDay = "01/01/" + year.ToString();
            ViewBag.lastDay = "12/31/" + year.ToString();
            var persons = new SelectList(db.AccountPersons.OrderByDescending(s => s.AccountPersonID).ToList(), "AccountPersonID", "AccountPerson1");
            ViewData["persons"] = persons;
            return View();
        }

        public ActionResult ManageAccounts()
        {
            return View();
        }

        public ActionResult ProfitAndLoss(FormCollection forms)
        {
            if (forms["PersonID"] != null)
            {
                Session["PersonID"] = forms["PersonID"];
                Models.AccountPerson PersonName = db.AccountPersons.Find(Convert.ToInt32(forms["PersonID"]));
                Session["PersonName"] = PersonName.AccountPerson1;
            }
            else
            {
                Models.AccountPerson PersonName = db.AccountPersons.Find(Convert.ToInt32(Session["PersonID"]));
                Session["PersonName"] = PersonName.AccountPerson1;
            }

            string firstDay = forms["firstDay"];
            string lastDay = forms["lastDay"];
            return Redirect("~/WebForms/ProfitAndLoss.aspx?PersonID="
                + Session["PersonID"]+"&firstDay="+firstDay+"&lastDay="+lastDay); // redirects to internal url
        }
    }
}