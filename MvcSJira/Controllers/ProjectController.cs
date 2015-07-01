using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using DomainClasses.Models;
using MvcSJira.Models;
using DataLayer;
using DataLayer.Context;
using AutoMapper.QueryableExtensions;
namespace MvcSJira.Controllers
{
    //Install-Package Microsoft.ASPNet.Mvc.Futures
     //install-package automapper
    public class ProjectController : Controller
    {
        private SJiraContext db ;
        ProjectModelFactory projectModelFactory;
        //
        // GET: /Default1/
        public ProjectController ()
	    {
            db = new SJiraContext();
            projectModelFactory = new ProjectModelFactory();
	    }
        
        public ActionResult Index()
        {
            var  projects = db.Projects.Include(p => p.ProjectCategory).Include(p => p.ApplicationUser).ToList();
            //var projectsModel = projects.Select(p => new ProjectModel()
            //{
            //    ProjectId = p.ProjectId,
            //    Name = p.Name,
            //    Code = p.Code,
            //    Lead = p.ApplicationUser.UserName

            //});
            var projectsModel = db.Projects.Include(p => p.ProjectCategory).Include(p => p.ApplicationUser)
                .Project().To<ProjectModel>();
            return View(projectsModel);
        }
       
        
        //
        // GET: /Default1/Details/5
        public ActionResult Details(int id = 0)
        {
            var project = db.Projects.Include(p => p.ProjectCategory).Include(p => p.ApplicationUser).Where(p => p.ProjectId == id); ;
            if (project == null)
            {
                return HttpNotFound();
            }
            ProjectModel projectModel = (ProjectModel)project.Select(p => new ProjectModel()
            {
                ProjectId = p.ProjectId,
                Name = p.Name,
                Code = p.Code,
                Lead = p.ApplicationUser.UserName,
                Category = p.ProjectCategory.Name

            }).FirstOrDefault();
            return View(projectModel);
        }
        public ActionResult Details1(int id = 0)
        {
            var project = db.Projects.Include(p => p.ProjectCategory).Include(p => p.ApplicationUser)
                .Where(p => p.ProjectId == id);
                //.Select(p => projectModelFactory.Create(p));

            if (project == null)
            {
                return HttpNotFound();
            }
            ProjectModel projectModel = (ProjectModel)project.Select(p => projectModelFactory.Create(p)).FirstOrDefault();

            return View(projectModel);
        }

        
        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.LeadId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ProjectCategoryId = new SelectList(db.ProjectCategories, "Id", "Name");
            return View();
        }
        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return this.RedirectToAction<ProjectController>(c => c.Index());
            }
            ViewBag.LeadId = new SelectList(db.Users, "Id", "UserName", project.LeadId);
            ViewBag.ProjectCategoryId = new SelectList(db.ProjectCategories, "Id", "Name", project.ProjectCategoryId);
            return View(project);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeadId = new SelectList(db.Users, "Id", "UserName", project.LeadId);
            ViewBag.ProjectCategoryId = new SelectList(db.ProjectCategories, "Id", "Name", project.ProjectCategoryId);
            return View(project);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return this.RedirectToAction<ProjectController>(c => c.Index());
            }
            ViewBag.LeadId = new SelectList(db.Users, "Id", "UserName", project.LeadId);
            ViewBag.ProjectCategoryId = new SelectList(db.ProjectCategories, "Id", "Name", project.ProjectCategoryId);
            return View(project);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return this.RedirectToAction<ProjectController>(c => c.Index());
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}