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
    public class InterviewSchedulesController : Controller
    {
        private Model1 db = new Model1();

        // GET: InterviewSchedules
        public ActionResult Index()
        {
            var interviewSchedules = db.InterviewSchedules.Include(i => i.Candidate).Include(i => i.PanelMember);
            return View(interviewSchedules.ToList());
        }

        // GET: InterviewSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewSchedule interviewSchedule = db.InterviewSchedules.Find(id);
            if (interviewSchedule == null)
            {
                return HttpNotFound();
            }
            return View(interviewSchedule);
        }

        // GET: InterviewSchedules/Create
        public ActionResult Create()
        {
            ViewBag.candidate_id = new SelectList(db.Candidates, "candidate_id", "name");
            ViewBag.panel_member_id = new SelectList(db.PanelMembers, "member_id", "name");
            return View();
        }

        // POST: InterviewSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "schedule_id,candidate_id,panel_member_id,interview_date,feedback")] InterviewSchedule interviewSchedule)
        {
            if (ModelState.IsValid)
            {
                db.InterviewSchedules.Add(interviewSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.candidate_id = new SelectList(db.Candidates, "candidate_id", "name", interviewSchedule.candidate_id);
            ViewBag.panel_member_id = new SelectList(db.PanelMembers, "member_id", "name", interviewSchedule.panel_member_id);
            return View(interviewSchedule);
        }

        // GET: InterviewSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewSchedule interviewSchedule = db.InterviewSchedules.Find(id);
            if (interviewSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.candidate_id = new SelectList(db.Candidates, "candidate_id", "name", interviewSchedule.candidate_id);
            ViewBag.panel_member_id = new SelectList(db.PanelMembers, "member_id", "name", interviewSchedule.panel_member_id);
            return View(interviewSchedule);
        }

        // POST: InterviewSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "schedule_id,candidate_id,panel_member_id,interview_date,feedback")] InterviewSchedule interviewSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interviewSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.candidate_id = new SelectList(db.Candidates, "candidate_id", "name", interviewSchedule.candidate_id);
            ViewBag.panel_member_id = new SelectList(db.PanelMembers, "member_id", "name", interviewSchedule.panel_member_id);
            return View(interviewSchedule);
        }

        // GET: InterviewSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewSchedule interviewSchedule = db.InterviewSchedules.Find(id);
            if (interviewSchedule == null)
            {
                return HttpNotFound();
            }
            return View(interviewSchedule);
        }

        // POST: InterviewSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterviewSchedule interviewSchedule = db.InterviewSchedules.Find(id);
            db.InterviewSchedules.Remove(interviewSchedule);
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
