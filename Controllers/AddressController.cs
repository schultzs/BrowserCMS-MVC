using BrowserCMS_MVC.DAL;
using BrowserCMS_MVC.Models;
using BrowserCMS_MVC.Models.ViewModels;
using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace BrowserCMS_MVC.Controllers
{
    public class AddressController : Controller
    {
        private CompanyContext db = new CompanyContext();

        /// <summary>
        /// GET: /Address/Create
        /// </summary>
        /// <param name="id">Company id</param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ActionResult Create(int id, int contactId)
        {
            AddressVM addr = new AddressVM();
            addr.CompanyId = id;
            addr.ContactId = contactId;
            addr.AddressTypeList = db.AddressTypes;

            return View(addr);
        }

        /// <summary>
        /// POST: /Address/Create
        /// </summary>
        /// <param name="id">Company id.</param>
        /// <param name="contactId"></param>
        /// <param name="newAddress"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, int contactId, [Bind(Include="Id,AddressLine1,AddressLine2,City,State,ZipCode,AddressType")] AddressVM newAddress)
        {
            if (ModelState.IsValid)
            {
                Address address = new Address();

                address = newAddress.viewModelToAddress(newAddress);
                address.AddressType = db.AddressTypes.Find(address.AddressType.Id);
                address.DateCreated = DateTime.Now;
                address.DateModified = DateTime.Now;

                db.Contacts.Find(contactId).Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Details", "Contact", new { id = id, contactId = contactId });
            }

            return View(newAddress);
        }

        /// <summary>
        /// GET: /Address/Edit/
        /// </summary>
        /// <param name="id">Company id.</param>
        /// <param name="contactId"></param>
        /// <param name="addrId"></param>
        /// <returns></returns>
        public ActionResult Edit(int id, int contactId, int addrId)
        {
            AddressVM model = new AddressVM();
            Address address = db.Addresses.Find(addrId);
            model = model.addressToViewModel(address);
            model.AddressTypeList = db.AddressTypes;
            model.CompanyId = id;
            model.ContactId = contactId;
            
            if (address == null)
            {
                return HttpNotFound();
            }
            ModelState.Clear();
            return View(model);
        }

        /// <summary>
        /// POST: /Address/Edit/
        /// </summary>
        /// <param name="id">Company id.</param>
        /// <param name="contactId"></param>
        /// <param name="updateAddress"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int contactId, [Bind(Include="Id,AddressLine1,AddressLine2,City,State,ZipCode,AddressType,ContactId,CompanyId")] AddressVM updateAddress)
        {
            if (ModelState.IsValid)
            {
                Address address = db.Addresses.Find(updateAddress.Id);

                if (address == null || address.Contact.Id != updateAddress.ContactId)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                address.AddressLine1 = updateAddress.AddressLine1;
                address.AddressLine2 = updateAddress.AddressLine2;
                address.AddressType = db.AddressTypes.Find(updateAddress.AddressType.Id);
                address.City = updateAddress.City;
                address.State = updateAddress.State;
                address.ZipCode = updateAddress.ZipCode;
                address.DateModified = DateTime.Now;

                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Contact", new { id = updateAddress.CompanyId, contactId = updateAddress.ContactId });
            }
            return View(updateAddress);
        }

        /// <summary>
        /// GET: /Address/Delete/
        /// </summary>
        /// <param name="id">Company id.</param>
        /// <param name="contactId"></param>
        /// <param name="addrId"></param>
        /// <returns></returns>
        public ActionResult Delete(int id, int contactId, int addrId)
        {
            Address address = db.Addresses.Find(addrId);
            if (address == null || address.Contact.Id != contactId)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        /// <summary>
        /// POST: /Address/Delete/
        /// </summary>
        /// <param name="id">Company id.</param>
        /// <param name="contactId"></param>
        /// <param name="addrId"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int contactId, int addrId)
        {
            Address address = db.Addresses.Find(addrId);
            db.Addresses.Remove(address);
            db.SaveChanges();
            return RedirectToAction("Details", "Contact", new { id = id, contactId = contactId });
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
