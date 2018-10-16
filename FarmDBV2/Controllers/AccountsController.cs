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

namespace FarmDBV2.Controllers
{
    public class AccountsController : Controller
    {
        private Models.FarmDBEntities2 db = new Models.FarmDBEntities2();

        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.AccountPerson).Include(a => a.AccountSubType);
            return View(accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.AccountPersonID = new SelectList(db.AccountPersons, "AccountPersonID", "AccountPerson1");
            ViewBag.AccountSubTypeID = new SelectList(db.AccountSubTypes, "AcctSubTypeID", "AcctSubType");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,AccountName,TaxFormRef,AccountPersonID,AccountSubTypeID,Active")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountPersonID = new SelectList(db.AccountPersons, "AccountPersonID", "AccountPerson1", account.AccountPersonID);
            ViewBag.AccountSubTypeID = new SelectList(db.AccountSubTypes, "AcctSubTypeID", "AcctSubType", account.AccountSubTypeID);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountPersonID = new SelectList(db.AccountPersons, "AccountPersonID", "AccountPerson1", account.AccountPersonID);
            ViewBag.AccountSubTypeID = new SelectList(db.AccountSubTypes, "AcctSubTypeID", "AcctSubType", account.AccountSubTypeID);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountNumber,AccountName,TaxFormRef,AccountPersonID,AccountSubTypeID,Active")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountPersonID = new SelectList(db.AccountPersons, "AccountPersonID", "AccountPerson1", account.AccountPersonID);
            ViewBag.AccountSubTypeID = new SelectList(db.AccountSubTypes, "AcctSubTypeID", "AcctSubType", account.AccountSubTypeID);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
