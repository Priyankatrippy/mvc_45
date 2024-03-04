using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppfinalMvcMarch3.Models;

namespace WebAppfinalMvcMarch3.Controllers 
{
    public class PanelMembersController : Controller
    {
        private Model1 db = new Model1();

        // GET: PanelMembers
        public ActionResult Index()
        {
            return View(db.PanelMembers.ToList());
        }

        // GET: PanelMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PanelMember panelMember = db.PanelMembers.Find(id);
            if (panelMember == null)
            {
                return HttpNotFound();
            }
            return View(panelMember);
        }

        // GET: PanelMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PanelMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "member_id,name,position,email")] PanelMember panelMember)
        {
            if (ModelState.IsValid)
            {
                db.PanelMembers.Add(panelMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(panelMember);
        }

        // GET: PanelMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PanelMember panelMember = db.PanelMembers.Find(id);
            if (panelMember == null)
            {
                return HttpNotFound();
            }
            return View(panelMember);
        }

        // POST: PanelMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "member_id,name,position,email")] PanelMember panelMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(panelMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(panelMember);
        }

        // GET: PanelMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PanelMember panelMember = db.PanelMembers.Find(id);
            if (panelMember == null)
            {
                return HttpNotFound();
            }
            return View(panelMember);
        }

        // POST: PanelMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PanelMember panelMember = db.PanelMembers.Find(id);
            db.PanelMembers.Remove(panelMember);
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
