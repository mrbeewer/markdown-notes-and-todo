using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarkdownManager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Services;
using System.Data.SqlClient;
using PagedList;

namespace MarkdownManager.Controllers
{

    
    [Authorize]
    public class ToDoController : Controller
    {
        private ApplicationDbContext db;
        private UserManager<MyUser> manager;

        public ToDoController()
        {
            db = new ApplicationDbContext();
            manager = new UserManager<MyUser>(new UserStore<MyUser>(db));
        }




        // GET: ToDo
        public ActionResult Index(string sortTagOrder, string sortDescOrder, string sortDoneOrder, string currentFilter, string searchString, int? page)
        {
            // Sort Order Criteria
            ViewBag.CurrentDescSort = sortDescOrder;
            ViewBag.CurrentDoneSort = sortDoneOrder;
            ViewBag.CurrentTagSort = sortTagOrder;
            ViewBag.DescriptionSortParam = sortDescOrder == "description_asc" ? "description_desc" : "description_asc";
            ViewBag.IsDoneSortParam = sortDoneOrder == "isDone_asc" ? "isDone_desc" : "isDone_asc";
            ViewBag.TagSortParam = sortTagOrder == "tag_asc" ? "tag_desc" : "tag_asc";

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

            // Find ToDos that belong to the user
            var todoes = from t in db.ToDoes select t;
            string currentUser = User.Identity.GetUserId();

            todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser);
            todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderBy(t => t.Tag);

            if (!String.IsNullOrEmpty(searchString))
            {
                todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser);
                todoes = todoes.Where(todo => todo.Tag.Contains(searchString));
            }

            // Order the ToDos as specified
            switch (sortDescOrder)
            {
                case "description_desc":
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderByDescending(t => t.Description);
                    break;
                case "description_asc":
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderBy(t => t.Description);
                    break;

            }

            switch(sortDoneOrder)
            {
                case "isDone_desc":
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderByDescending(t => t.IsDone ? 0 : 1);
                    break;
                case "isDone_asc":
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderBy(t => t.IsDone ? 0 : 1);
                    break;

            }
                
            switch(sortTagOrder)
            {
                case "tag_desc":
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderByDescending(t => t.Tag);
                    break;
                case "tag_asc":
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderBy(t => t.Tag);
                    break;
            }
                
        

            // Pagination settings and render the view
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(todoes.ToPagedList(pageNumber, pageSize));
        }


        // GET: ToDo/Details/5
        // This route is not currently being accessed, it seems unnecessary in the current version
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDoes.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }


        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsDone,Tag")] ToDo toDo)
        {
            string currentUser = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                toDo.ApplicationUserID = currentUser;
                db.ToDoes.Add(toDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDo);
        }


        // GET: ToDo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDoes.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }
        
        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsDone,Tag")] ToDo toDo)
        {
            string currentUser = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.Entry(toDo).State = EntityState.Modified;
                toDo.ApplicationUserID = currentUser;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDo);

        }


        // GET: ToDo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDoes.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        // POST: ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDo toDo = db.ToDoes.Find(id);
            db.ToDoes.Remove(toDo);
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
