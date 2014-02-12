using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrowserCMS_MVC.Models.ViewModels;
using BrowserCMS_MVC.DAL;
using BrowserCMS_MVC.Models;

namespace BrowserCMS_MVC.Controllers
{
    public class TypeController : Controller
    {
        private CompanyContext db = new CompanyContext();

        /// <summary>
        /// GET: /Type/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            TypeVM model = new TypeVM();
            model.addrTypes = db.AddressTypes;
            model.emailTypes = db.EmailTypes;
            model.phoneTypes = db.PhoneTypes;

            return View(model);
        }

        //
        // GET: /Type/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Type/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Type/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Type/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Type/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Type/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Type/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult _AddressType(AddressType model)
        {
            return View("_AddressType", model);
        }

        public ActionResult _EmailAddressType(EmailType model)
        {
            return View("_EmailAddressType", model);
        }

        public ActionResult _PhoneType(PhoneType model)
        {
            return View("_PhoneType", model);
        }
    }
}
