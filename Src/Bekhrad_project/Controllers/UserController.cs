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
using System.Web.UI;
using System.Web.Helpers;
using Newtonsoft.Json;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Bekhrad_project.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupUserRepository _groupUser;
        private DataContext db=new DataContext();  

        public UserController(IUserRepository userRepository,IGroupUserRepository groupUser)
        {
            _userRepository=userRepository;
            _groupUser=groupUser;   
        }
        public async Task<ActionResult> Index()
        {
            return View(await _userRepository.getAllUsers());
        }
      
        public async Task<ActionResult> getAll([DataSourceRequest] DataSourceRequest request)
        {
            bool proxyCreation = db.Configuration.ProxyCreationEnabled;
            try
            {
                db.Configuration.ProxyCreationEnabled = false;

                var data = await db.UserInformations.ToListAsync();

                return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally
            {
                db.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }
 

        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = await _userRepository.getUserById(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "userid,name,family,age,email,groupid")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.AddUser(userInformation);
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.Groups, "groupid", "groupname", userInformation.groupid);
            return View(userInformation);
        }

        //public async Task<ActionResult> Edit(int id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserInformation userInformation = await _userRepository.getUserById(id);
        //    if (userInformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", userInformation.groupid);
        //    return View(userInformation);
        //}


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult edit(UserInformation userInformation, [DataSourceRequest] DataSourceRequest request)
        {
            if (userInformation != null && ModelState.IsValid)
            {
                 _userRepository.UpdateUser(userInformation);
            }

            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName");
            bool proxyCreation = db.Configuration.ProxyCreationEnabled;
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                return  Json(new[] { userInformation }.ToDataSourceResult(request, ModelState));
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally
            {
                db.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }


        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             var response=await _userRepository.DeleteUser(id);
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
            var respons=await _userRepository.DeleteConfirme(id);
            if (respons==true)
            {
             return RedirectToAction("Index");    
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userRepository.Dispose();  
            }
            base.Dispose(disposing);
        }
    }
}
