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
using Bekhrad_project.Repository;
using Bekhrad_project.Repository.User;

namespace Bekhrad_project.Controllers
{
    public class GroupsUserController : Controller
    {
        private readonly IGroupUserRepository _groupUserRepository;

        public GroupsUserController(IGroupUserRepository groupUserRepository)
        {
            _groupUserRepository = groupUserRepository;
        }

  
        public async Task<ActionResult> Index()
        {
            return View(await _groupUserRepository.getAllGroup());
        }

 
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupUser group = await _groupUserRepository.getGroupById(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

    
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GroupId,GroupName,createGroupTime")] GroupUser group)
        {
            if (ModelState.IsValid)
            {
                await _groupUserRepository.AddGroup(group);
                return RedirectToAction("Index");
            }

            return View(group);
        }


        public async Task<ActionResult> Edit(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupUser userInformation = await _groupUserRepository.getGroupById(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GroupId,GroupName,createGroupTime")] GroupUser group)
        {
            if (ModelState.IsValid)
            {
                await _groupUserRepository.UpdateGroup(group);
                return RedirectToAction("Index");
            }
            return View(group);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var response = await _groupUserRepository.DeleteGroup(id);
            if (response == false)
            {
                return HttpNotFound();
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
             await _groupUserRepository.DeleteConfirme(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _groupUserRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
