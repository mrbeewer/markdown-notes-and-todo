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
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ParentFolderSortParam = String.IsNullOrEmpty(sortOrder) ? "parentfolder_desc" : "";

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


            var documents = from d in db.Documents select d;
            string currentUser = User.Identity.GetUserId();

            if (!String.IsNullOrEmpty(searchString))
            {
                documents = documents.Where(doc => doc.ApplicationUserID == currentUser);
                documents = documents.Where(doc => doc.ParentFolder.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    documents = documents.Where(doc => doc.ApplicationUserID == currentUser).OrderByDescending(d => d.Name);
                    break;
                case "parentfolder_desc":
                    documents = documents.Where(doc => doc.ApplicationUserID == currentUser).OrderByDescending(d => d.ParentFolder);
                    break;
                default:
                    documents = documents.Where(doc => doc.ApplicationUserID == currentUser).OrderBy(d => d.ParentFolder);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(documents.ToPagedList(pageNumber, pageSize));
        }

        // GET: Document/Details/5
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text,ParentFolder")] Document document)
        {
            //document.Text = Server.HtmlDecode(document.Text);
            string currentUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                document.ApplicationUserID = currentUser;
                db.Documents.Add(document);
                db.SaveChanges();
                var id = db.Documents.Find(document.Id).Id;
                //var id = documentEdit.Id;
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                //return RedirectToAction("Index");
                //return new EmptyResult();
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
            //return View(document);
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
