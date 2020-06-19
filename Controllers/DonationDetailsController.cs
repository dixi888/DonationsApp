﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Donations_Software.Models;

namespace Donations_Software.Controllers
{
    public class DonationDetailsController : Controller
    {
        private teamdonationsEntities db = new teamdonationsEntities();

        // GET: DonationDetails
        public ActionResult Index()
        {
            return View(db.DonationDetails.ToList());
        }

        // GET: DonationDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationDetail donationDetail = db.DonationDetails.Find(id);
            if (donationDetail == null)
            {
                return HttpNotFound();
            }
            return View(donationDetail);
        }

        // GET: DonationDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonationDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationID,DonationName,Description,ImageURL,Price,isMonthly")] DonationDetail donationDetail)
        {
            if (ModelState.IsValid)
            {
                db.DonationDetails.Add(donationDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donationDetail);
        }

        // GET: DonationDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationDetail donationDetail = db.DonationDetails.Find(id);
            if (donationDetail == null)
            {
                return HttpNotFound();
            }
            return View(donationDetail);
        }

        // POST: DonationDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationID,DonationName,Description,ImageURL,Price,isMonthly")] DonationDetail donationDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donationDetail);
        }

        // GET: DonationDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationDetail donationDetail = db.DonationDetails.Find(id);
            if (donationDetail == null)
            {
                return HttpNotFound();
            }
            return View(donationDetail);
        }

        // POST: DonationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonationDetail donationDetail = db.DonationDetails.Find(id);
            db.DonationDetails.Remove(donationDetail);
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
