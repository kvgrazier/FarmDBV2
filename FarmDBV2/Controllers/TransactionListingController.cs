using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmDBV2;
using FarmDBV2.Models;
using PagedList;

namespace FarmDBV2.Controllers
{
    public class TransactionListingController : Controller
    {
        private Models.FarmDBEntities2 db = new Models.FarmDBEntities2();
        [HttpPost]
        public ActionResult TransactionListing(FormCollection forms, int? page, string sortOrder)
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
            ViewBag.CurrentSort = sortOrder;
            //Models.FarmDBEntities2 db = new Models.FarmDBEntities2();
            string firstDay = forms["firstDay"];
            string lastDay = forms["lastDay"];
            ViewBag.firstDay = firstDay;
            ViewBag.lastDay = lastDay;
        
            var transactions = (from l in
                       db.tvfTransactionListing(Convert.ToDateTime(firstDay), Convert.ToDateTime(lastDay), Convert.ToInt32(Session["PersonID"].ToString()))
                                select l);
            IEnumerable<tvfTransactionListing_Result> x = transactions.AsEnumerable<tvfTransactionListing_Result>().OrderByDescending(s => s.TransactionDate);
            ViewBag.DateSortParm = "TransactionDate";
            ViewBag.AcctSortParm = "AcctNumber";
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(x.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult TransactionListing(int? page, string firstDay, string lastDay, string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            //Models.FarmDBEntities2 db = new Models.FarmDBEntities2();
            ViewBag.firstDay = firstDay;
            ViewBag.lastDay = lastDay;
            var transactions = (from l in
                       db.tvfTransactionListing(Convert.ToDateTime(firstDay), Convert.ToDateTime(lastDay), Convert.ToInt32(Session["PersonID"].ToString()))
                                select l);
            IEnumerable<tvfTransactionListing_Result> x = transactions.AsEnumerable<tvfTransactionListing_Result>();
            switch (sortOrder)
            {
                case "TransactionDate_desc":
                    x = x.OrderBy(s => s.TransactionDate);
                    ViewBag.DateSortParm = "TransactionDate";
                    ViewBag.AcctSortParm = "AcctNumber_desc";
                    break;
                case "AcctNumber":
                    x = x.OrderByDescending(s => s.AcctNumber);
                    ViewBag.AcctSortParm = "AcctNumber_desc";
                    break;
                case "AcctNumber_desc":
                    x = x.OrderBy(s => s.AcctNumber);
                    ViewBag.AcctSortParm = "AcctNumber";
                    break;
                default:  // TransactionDate
                    x = x.OrderByDescending(s => s.TransactionDate);
                    ViewBag.DateSortParm = "TransactionDate_desc";
                    ViewBag.AcctSortParm = "AcctNumber_desc";
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(x.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.AccountNumber1 = new SelectList(db.Accounts, "AccountNumber", "AccountName");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,TransactionDate,TransactionDescription,Quantity,AccountNumber1,Account1Amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountNumber1 = new SelectList(db.Accounts, "AccountNumber", "AccountName", transaction.AccountNumber1);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountNumber1 = new SelectList(db.Accounts, "AccountNumber", "AccountName", transaction.AccountNumber1);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionID,TransactionDate,TransactionDescription,Quantity,AccountNumber1,Account1Amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountNumber1 = new SelectList(db.Accounts, "AccountNumber", "AccountName", transaction.AccountNumber1);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

 
