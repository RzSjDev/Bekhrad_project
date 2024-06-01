using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bekhrad_project.Models.MyModel;

namespace Bekhrad_project.Controllers
{
    public class UserController : Controller
    {
        private DataContext db = new DataContext();

        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await db.UserInformations.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = await db.UserInformations.FindAsync(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,Name,Family,Age,Email")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                db.UserInformations.Add(userInformation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userInformation);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = await db.UserInformations.FindAsync(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,Name,Family,Age,Email")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInformation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userInformation);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = await db.UserInformations.FindAsync(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserInformation userInformation = await db.UserInformations.FindAsync(id);
            db.UserInformations.Remove(userInformation);
            await db.SaveChangesAsync();
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
