using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarkdownManager.Models;
using PagedList;
using Microsoft.AspNet.Identity;

namespace MarkdownManager.Controllers
{
    public class DocumentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Document
        public ActionResult Index(string sortParentFolderOrder, string sortNameOrder, string currentFilter, string searchString, int? page)
        {
            // Sorting Criteria
            ViewBag.CurrentNameSort = sortNameOrder;
            ViewBag.CurrentParentFolderSort = sortParentFolderOrder;
            ViewBag.NameSortParam = sortNameOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.ParentFolderSortParam = sortParentFolderOrder == "parentfolder_asc" ? "parentfolder_desc" : "parentfolder_asc";

            // Pagination and persistent filtering
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            // Find documents that belong to the user
            var documents = from d in db.Documents select d;
            string currentUser = User.Identity.GetUserId();

            documents = documents.Where(doc => doc.ApplicationUserID == currentUser);
            documents = documents.Where(doc => doc.ApplicationUserID == currentUser).OrderBy(d => d.ParentFolder);

            if (!String.IsNullOrEmpty(searchString))
            {
                documents = documents.Where(doc => doc.ApplicationUserID == currentUser);
                documents = documents.Where(doc => doc.ParentFolder.Contains(searchString));
            }

            // Order the found documents as specified
            switch (sortNameOrder)
            {
                case "name_desc":
                    documents = documents.Where(doc => doc.ApplicationUserID == currentUser).OrderByDescending(d => d.Name);
                    break;
                case "name_asc":
                    documents = documents.Where(doc => doc.ApplicationUserID == currentUser).OrderBy(d => d.Name);
                    break;
            }

            switch (sortParentFolderOrder)
            {
                case "parentfolder_desc":
                    documents = documents.Where(doc => doc.ApplicationUserID == currentUser).OrderByDescending(d => d.ParentFolder);
                    break;
                case "parentfolder_asc":
                    documents = documents.Where(doc => doc.ApplicationUserID == currentUser).OrderBy(d => d.ParentFolder);
                    break;
            }

            // Specify the pagination settings and render view
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(documents.ToPagedList(pageNumber, pageSize));
        }

        
        // GET: Document/Details/5
        // This route is not currently being accessed, it seems unnecessary in the current version
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }


        // GET: Document/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        // Route adjusted so upon creation, redirect to the edit of that note/document
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text,ParentFolder")] Document document)
        {
            string currentUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                document.ApplicationUserID = currentUser;
                db.Documents.Add(document);
                db.SaveChanges();
                var id = db.Documents.Find(document.Id).Id;
                return RedirectToAction("Edit", new { id = id });
            }
            return View(document);
        }


        // GET: Document/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Document/Edit/5
        // Route adjusted to provide a "success" message upon saving the document. Will keep the document open
        //  so the user can save as they work (and not be redirected to the index)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Text,ParentFolder")] Document document)
        {
            string currentUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                document.ApplicationUserID = currentUser;
                db.SaveChanges();
                ViewData["message"] = "Note Saved!";
                return View();
            }
            return View(document);
        }


        // GET: Document/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Dispose of the database connection
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
