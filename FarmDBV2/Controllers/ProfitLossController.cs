using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmDBV2.Models;

namespace FarmDBV2.Controllers
{
    public class ProfitLossController : Controller
    {
        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            Models.FarmDBEntities2 db = new Models.FarmDBEntities2();
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
            ViewBag.firstDay = firstDay;
            ViewBag.lastDay = lastDay;
            var transactions = (from l in
                       db.tvfProfitLoss(Convert.ToDateTime(firstDay), Convert.ToDateTime(lastDay), Convert.ToInt32(Session["PersonID"].ToString()))
                                select l);
            IEnumerable<tvfProfitLoss_Result> x = transactions.AsEnumerable<tvfProfitLoss_Result>().OrderBy(s => s.SortOrder);
            return View(x);
        }
    }
}