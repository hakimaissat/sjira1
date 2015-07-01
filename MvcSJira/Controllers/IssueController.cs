using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainClasses.Models;
using MvcSJira.Models;
using DataLayer;
using DataLayer.Context;

namespace MvcSJira.Controllers
{
    public class IssueController : Controller
    {
        private SJiraContext db = new SJiraContext();

        //
        // GET: /Issue/

        public ActionResult Index()
        {
            var issues = db.Issues.Include(i => i.IssuePriority).Include(i => i.IssueResolution).Include(i => i.IssueType).Include(i => i.Project);
            return View(issues.ToList());
        }
        //
        // GET: /Issue/

        public ActionResult My_Open_Issues()
        {
           
            ViewBag.Menu = "My Open Issues ToolBar";
            ViewBag.SideBar = "My Open Issues SideBar";
            ViewBag.ToolBar = "My Open Issues ToolBar";
            var issues = db.Issues.Include(i => i.IssuePriority)
                .Include(i => i.IssueResolution)
                .Include(i => i.IssueType)
                .Include(i => i.Project).Select(o => new My_Open_Issues_Model 
                { 
                    Key=o.Code,
                   
                    Summary =o.Summary,
                    Assignee = o.Assignee.UserName,
                    Reporter ="",
                    Status ="",
                    Resolution=o.IssueResolution.Name ,
                    Created =o.ModifiedDate,
                    Updated =o.ModifiedDate,
                    Due = o.ModifiedDate,
                }).ToList();

            return View(issues);
        }
        //
        // GET: /Issue/Details/5

        public ActionResult Details(Guid id)
        {
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        //
        // GET: /Issue/Create

        public ActionResult Create()
        {
            ViewBag.IssuePriorityId = new SelectList(db.IssuePriorities, "Id", "Name");
            ViewBag.IssueResolutionId = new SelectList(db.IssueResolutions, "Id", "Name");
            ViewBag.IssueTypeId = new SelectList(db.IssueTypes, "Id", "Name");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        //
        // POST: /Issue/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Issue issue)
        {
            if (ModelState.IsValid)
            {
                issue.IssueId = Guid.NewGuid();
                db.Issues.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IssuePriorityId = new SelectList(db.IssuePriorities, "Id", "Name", issue.IssuePriorityId);
            ViewBag.IssueResolutionId = new SelectList(db.IssueResolutions, "Id", "Name", issue.IssueResolutionId);
            ViewBag.IssueTypeId = new SelectList(db.IssueTypes, "Id", "Name", issue.IssueTypeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", issue.ProjectId);
            return View(issue);
        }

        //
        // GET: /Issue/Edit/5

        public ActionResult Edit(Guid id)
        {
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            ViewBag.IssuePriorityId = new SelectList(db.IssuePriorities, "Id", "Name", issue.IssuePriorityId);
            ViewBag.IssueResolutionId = new SelectList(db.IssueResolutions, "Id", "Name", issue.IssueResolutionId);
            ViewBag.IssueTypeId = new SelectList(db.IssueTypes, "Id", "Name", issue.IssueTypeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", issue.ProjectId);
            return View(issue);
        }

        //
        // POST: /Issue/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Issue issue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IssuePriorityId = new SelectList(db.IssuePriorities, "Id", "Name", issue.IssuePriorityId);
            ViewBag.IssueResolutionId = new SelectList(db.IssueResolutions, "Id", "Name", issue.IssueResolutionId);
            ViewBag.IssueTypeId = new SelectList(db.IssueTypes, "Id", "Name", issue.IssueTypeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", issue.ProjectId);
            return View(issue);
        }

        //
        // GET: /Issue/Delete/5

        public ActionResult Delete(Guid id )
        {
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        //
        // POST: /Issue/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Issue issue = db.Issues.Find(id);
            db.Issues.Remove(issue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}