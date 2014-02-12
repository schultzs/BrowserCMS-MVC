using BrowserCMS_MVC.DAL;
using BrowserCMS_MVC.Models;
using BrowserCMS_MVC.Models.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BrowserCMS_MVC.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyContext db = new CompanyContext();

        /// <summary>
        /// GET: /Company/
        /// Returns list of all companies to view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        /// <summary>
        /// GET: /Company/
        /// Returns company details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //ViewBag.Id = id;
            Company company = db.Companies.Find(id);
            
            if (company == null)
            {
                return HttpNotFound();
            }
            
            return View(company);
        }

        /// <summary>
        /// GET: /Company/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: /Company/Create
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] CompanyVM newCompany)
        {
            if (ModelState.IsValid)
            {
                Company company = new Company();
                company = newCompany.viewModelToCompany(newCompany);
                company.DateCreated = DateTime.Now;
                company.DateModified = DateTime.Now;
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newCompany);
        }

        /// <summary>
        /// GET: /Company/Edit/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        /// <summary>
        /// POST: /Company/Edit/
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                Company comp = db.Companies.Find(company.Id);
                comp.Name = company.Name;
                comp.DateModified = DateTime.Now;

                db.Entry(comp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", company.Id);
            }
            return View(company);
        }

        /// <summary>
        /// GET: /Company/Delete/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        /// <summary>
        /// POST: /Company/Delete/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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
