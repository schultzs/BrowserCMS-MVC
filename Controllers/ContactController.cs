using BrowserCMS_MVC.DAL;
using BrowserCMS_MVC.Models;
using BrowserCMS_MVC.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BrowserCMS_MVC.Controllers
{
    public class ContactController : Controller
    {
        private CompanyContext db = new CompanyContext();

        /// <summary>
        /// GET: /Company/{id}/Contact/
        /// </summary>
        /// <param name="id">Company id</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;

            IEnumerable<Contact> contacts = db.Contacts.Where(c => c.Company.Id == id);
            return View(contacts);
        }

        /// <summary>
        /// GET: /Company/{id}/Contact/{contactId}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ActionResult Details(int id, int? contactId)
        {
            ContactVM model = new ContactVM();

            if (contactId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = db.Contacts.Find(contactId);
            if (contact == null || contact.Company.Id != id)
            {
                return HttpNotFound();
            }
            
            model = model.contactToViewModel(contact);
            model.Addresses = GetAddresses((int)contactId);
            model.EmailAddresses = GetEmailAddresses((int)contactId);
            model.PhoneNumbers = GetPhoneNumbers((int)contactId);

            return View(model);
        }

        /// <summary>
        /// GET: /Company/{id}/Contact/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: /Company/{id}/Contact/Create
        /// </summary>
        /// <param name="id">Company id.</param>
        /// <param name="newContact">New contact information.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, [Bind(Include="Id,FirstName,LastName")] ContactVM newContact)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                
                contact.DateCreated = DateTime.Now;
                contact.DateModified = DateTime.Now;
                contact.DateLastContacted = DateTime.Now;
                contact.FirstName = newContact.FirstName;
                contact.LastName = newContact.LastName;

                db.Companies.Find(id).Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Details", "Company", new { id = id });
            }

            return View(newContact);
        }

        /// <summary>
        /// GET: /Company/{id}/Contact/{contactId}/Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ActionResult Edit(int id, int? contactId)
        {
            if (contactId == null)
            {
                return View("Create");
            }
            Contact contact = db.Contacts.Find(contactId);
            if (contact == null || contact.Company.Id != id)
            {
                return HttpNotFound();
            }
            ContactVM model = new ContactVM();
            model = model.contactToViewModel(contact);
            ModelState.Clear();
            return View(model);
        }

        /// <summary>
        /// POST: /Company/{id}/Contact/{contactId}/Edit
        /// </summary>
        /// <param name="id">Company id.</param>
        /// <param name="contactId"></param>
        /// <param name="updateContact">Updated contact information.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int contactId, [Bind(Include="Id,CompanyId,FirstName,LastName")] ContactVM updateContact)
        {
            if (ModelState.IsValid)
            {
                Contact contact = db.Contacts.Find(updateContact.Id);
                
                if(contact == null || contact.Company.Id != updateContact.CompanyId)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                contact.FirstName = updateContact.FirstName;
                contact.LastName = updateContact.LastName;
                contact.DateModified = DateTime.Now;

                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Contact", new { id = contact.Company.Id, contactId = contact.Id });
            }
            return View(updateContact);
        }

        /// <summary>
        /// GET: /Contact/Delete/{contactId}
        /// </summary>
        /// <param name="id">Company id.</param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ActionResult Delete(int id, int? contactId)
        {
            if (contactId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(contactId);
            if (contact == null || contact.Company.Id != id)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        /// <summary>
        /// POST: /Contact/Delete/{contactId}
        /// </summary>
        /// <param name="id">Company id.</param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int contactId)
        {
            Contact contact = db.Contacts.Find(contactId);
            if (contact.Company.Id == id)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Details", "Company", new { id = id });
        }

        /// <summary>
        /// Gets list of addresses associated with a specific contact.
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        private ICollection<AddressVM> GetAddresses(int contactId)
        {
            AddressVM vm = new AddressVM();
            List<Address> addresses = db.Addresses.Where(c => c.Contact.Id == contactId).ToList();
            ICollection<AddressVM> addressList = new List<AddressVM>();

            foreach (Address address in addresses)
            {
                addressList.Add(vm.addressToViewModel(address));
            }

            return addressList;
        }

        /// <summary>
        /// Gets list of email addresses associated with a specific contact.
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        private ICollection<EmailVM> GetEmailAddresses(int contactId)
        {
            EmailVM vm = new EmailVM();
            List<Email> emails = db.EmailAddresses.Where(c => c.Contact.Id == contactId).ToList();
            ICollection<EmailVM> emailList = new List<EmailVM>();

            foreach (Email email in emails)
            {
                emailList.Add(vm.emailToViewModel(email));
            }

            return emailList;
        }

        /// <summary>
        /// Gets list of phone numbers associated with a specific contact.
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        private ICollection<PhoneVM> GetPhoneNumbers(int contactId)
        {
            PhoneVM vm = new PhoneVM();
            List<Phone> phoneNumbers = db.PhoneNumbers.Where(c => c.Contact.Id == contactId).ToList();
            ICollection<PhoneVM> phoneList = new List<PhoneVM>();

            foreach (Phone phone in phoneNumbers)
            {
                phoneList.Add(vm.phoneToViewModel(phone));
            }

            return phoneList;
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
