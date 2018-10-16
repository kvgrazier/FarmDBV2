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
    public class AccountSubTypesController : Controller
    {
        private Models.FarmDBEntities2 db = new Models.FarmDBEntities2();

        // GET: AccountSubTypes
        public ActionResult Index()
        {
            var accountSubTypes = db.AccountSubTypes.Include(a => a.AccountType);
            return View(accountSubTypes.ToList());
        }

        // GET: AccountSubTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.AccountSubType accountSubType = db.AccountSubTypes.Find(id);
            if (accountSubType == null)
            {
                return HttpNotFound();
            }
            return View(accountSubType);
        }

        // GET: AccountSubTypes/Create
        public ActionResult Create()
        {
            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "AccountTypeID", "AccountType1");
            return View();
        }

        // POST: AccountSubTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AcctSubTypeID,AcctSubType,AccountTypeID,SortOrder")] AccountSubType accountSubType)
        {
            if (ModelState.IsValid)
            {
                db.AccountSubTypes.Add(accountSubType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "AccountTypeID", "AccountType1", accountSubType.AccountTypeID);
            return View(accountSubType);
        }

        // GET: AccountSubTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.AccountSubType accountSubType = db.AccountSubTypes.Find(id);
            if (accountSubType == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "AccountTypeID", "AccountType1", accountSubType.AccountTypeID);
            return View(accountSubType);
        }

        // POST: AccountSubTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcctSubTypeID,AcctSubType,AccountTypeID,SortOrder")] AccountSubType accountSubType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountSubType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "AccountTypeID", "AccountType1", accountSubType.AccountTypeID);
            return View(accountSubType);
        }

        // GET: AccountSubTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.AccountSubType accountSubType = db.AccountSubTypes.Find(id);
            if (accountSubType == null)
            {
                return HttpNotFound();
            }
            return View(accountSubType);
        }

        // POST: AccountSubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.AccountSubType accountSubType = db.AccountSubTypes.Find(id);
            db.AccountSubTypes.Remove(accountSubType);
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
