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
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DescriptionSortParam = String.IsNullOrEmpty(sortOrder) ? "description_desc" : "";
            ViewBag.IsDoneSortParam = String.IsNullOrEmpty(sortOrder) ? "isDone_asc" : "";
            ViewBag.TagSortParam = String.IsNullOrEmpty(sortOrder) ? "tag_asc" : "";

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


            var todoes = from t in db.ToDoes select t;
            string currentUser = User.Identity.GetUserId();

            if (!String.IsNullOrEmpty(searchString))
            {
                todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser);
                todoes = todoes.Where(todo => todo.Tag.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "description_desc":
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderByDescending(t => t.Description);
                    break;
                case "isDone_asc":
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderBy(t => t.IsDone ? 0 : 1);
                    break;
                case "tag_asc":
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderBy(t => t.Tag);
                    break;
                default:
                    todoes = todoes.Where(todo => todo.ApplicationUserID == currentUser).OrderByDescending(t => t.IsDone ? 0 : 1);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(todoes.ToPagedList(pageNumber, pageSize));
        }




        // GET: ToDo/Details/5
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            return View(toDo);
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
