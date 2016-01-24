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

namespace MarkdownManager.Controllers
{

    
    [Authorize]
    public class ToDoController : Controller
    {

        //private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext db;
        private UserManager<MyUser> manager;

        public ToDoController()
        {
            db = new ApplicationDbContext();
            manager = new UserManager<MyUser>(new UserStore<MyUser>(db));
        }

        [WebMethod]
        public static void UpdateDb(int eid)
        {
            if (eid != null)
            {
                try
                {
                    string data = string.Empty;
                    var con = new SqlConnection();
                    // Chenge Staus For check  
                    var q = "Select IsDone from ToDoes Where id='" + eid + "'";
                    var command = new SqlCommand(q, con);
                    con.Open();
                    SqlDataReader readData = command.ExecuteReader();
                    while (readData.Read())
                    {
                        data = readData["status"].ToString();
                        con.Close();
                        if (data == "False")
                        {
                            using (var con2 = new SqlConnection())
                            {
                                var query = "update ToDoes set IsDone='True' where id='" + eid + "'";
                                con2.Open();
                                var cmd = new SqlCommand(query, con2);
                                cmd.ExecuteNonQuery();
                                con2.Close();
                            }
                        }
                        else
                        {
                            using (var con1 = new SqlConnection())
                            {
                                var query = "update ToDoes set IsDone='False' where id='" + eid + "'";
                                con1.Open();
                                var cmd = new SqlCommand(query, con1);
                                cmd.ExecuteNonQuery();
                                con1.Close();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        //protected UserManager<ApplicationUser> UserManager { get; set; }
        //private UserManager<MyUser> manager;
        //manager = new UserManager<MyUser>(new UserStore<MyUser>(db));
        //this.ApplicationDbContext = new ApplicationDbContext();
        //UserManager  = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        // ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        // GET: ToDo
        public ActionResult Index()
        {
            //var user = UserManager.FindById(User.Identity.GetUserId());
            //var user1 = 

            //var currentUser = db.Users.Where(cUser => cUser.UserName == User.Identity.Name).FirstOrDefault();
            //var currentUser = manager.FindById(User.Identity.GetUserId());
            string currentUser = User.Identity.GetUserId();
            var items = db.ToDoes.ToList().Where(todo => todo.ApplicationUserID == currentUser);
            
           // var itemsList = currentUser.ToDo;
            //if (items != null)
            //{
            //    ViewData["TodoListItems"] = items;
            //}
            
            return View(db.ToDoes.ToList().Where(todo => todo.ApplicationUserID == currentUser));
            //return View();
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
            //var currentUser = db.Users.Where(cUser => cUser.UserName == User.Identity.Name).FirstOrDefault();
            //var user = user;
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            //var currentUser = manager.FindById(User.Identity.GetUserId());
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
        //[ValidateAntiForgeryToken]
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
