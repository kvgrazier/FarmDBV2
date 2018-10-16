using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.Data;
using FarmDBV2.Models;

namespace FarmDBV2.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Test()
        {
            // Models.FarmDBEntities2 db = new Models.FarmDBEntities2();
            // if (forms["PersonID"] != null)
            // {
            //     Session["PersonID"] = forms["PersonID"];
            //     Models.AccountPerson PersonName = db.AccountPersons.Find(Convert.ToInt32(forms["PersonID"]));
            //     Session["PersonName"] = PersonName.AccountPerson1;
            // }
            // else
            // {
            //     Models.AccountPerson PersonName = db.AccountPersons.Find(Convert.ToInt32(Session["PersonID"]));
            //     Session["PersonName"] = PersonName.AccountPerson1;
            // }
            // string firstDay = forms["firstDay"];
            // string lastDay = forms["lastDay"];
            // ViewBag.firstDay = firstDay;
            // ViewBag.lastDay = lastDay;

            // var transactions = (from l in
            //db.tvfProfitLoss(Convert.ToDateTime(firstDay), Convert.ToDateTime(lastDay), Convert.ToInt32(Session["PersonID"].ToString()))
            //                     select l);
            // List<tvfProfitLoss_Result> PL = transactions.ToList<tvfProfitLoss_Result>();

            // //Step 1 : Create a Local Report.
            // LocalReport localReport = new LocalReport();

            // //Step 2 : Specify Report Path.
            // localReport.ReportPath = Server.MapPath("~/Views/Reports/ProfitAndLoss.rdlc");

            // //Step 3 : Create Report DataSources
            // localReport.DataSources.Clear();
            // ReportDataSource rdc = new ReportDataSource("ProfitAndLossSet", PL);
            // localReport.DataSources.Add(rdc);
            // localReport.Refresh();
            // //localReport.DataBind();


            // //Step 5 : Call render method on local Report to generate report contents in Bytes array
            // string deviceInfo = "<DeviceInfo>" +
            //  "  <OutputFormat>PDF</OutputFormat>" +
            //  "</DeviceInfo>";
            // Warning[] warnings;
            // string[] streams;
            // string mimeType;
            // byte[] renderedBytes;
            // string encoding;
            // string fileNameExtension;
            // //Render the report           
            // renderedBytes = localReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);


            // //Step 6 : Set Response header to pass filename that will be used while saving report.
            // Response.AddHeader("Content-Disposition",
            //  "attachment; filename=UnAssignedLevels.pdf");

            // //Step 7 : Return file content result
            // return new FileContentResult(renderedBytes, mimeType);
            return View();
        }

    }
}