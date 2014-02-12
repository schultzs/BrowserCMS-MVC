using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrowserCMS_MVC.Models.ViewModels
{
    /// <summary>
    /// View model for a contact
    /// </summary>
    public class ContactVM
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        [Required, StringLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(40), Display(Name = "Last Name")]
        public string LastName { get; set; }

        public ICollection<PhoneVM> PhoneNumbers { get; set; }

        public ICollection<EmailVM> EmailAddresses { get; set; }

        public ICollection<AddressVM> Addresses { get; set; }

        [Display(Name = "Date Contacted")]
        public DateTime DateLastContacted { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }

        public ContactVM contactToViewModel(Contact contact)
        {
            ContactVM model = new ContactVM
            {
                Id = contact.Id,
                CompanyId = contact.Company.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                DateLastContacted = contact.DateLastContacted,
                DateCreated = contact.DateCreated,
                DateModified = contact.DateModified
            };

            return model;
        }

        public Contact viewModelToContact(ContactVM model)
        {
            Contact contact = new Contact
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateLastContacted = model.DateLastContacted,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified
            };

            ICollection<Address> addressList = new List<Address>();
            foreach (AddressVM address in model.Addresses)
            {
                addressList.Add(address.viewModelToAddress(address));
            }
            contact.Addresses = addressList;

            ICollection<Email> emailList = new List<Email>();
            foreach (EmailVM emails in model.EmailAddresses)
            {
                emailList.Add(emails.viewModelToEmail(emails));
            }
            contact.EmailAddresses = emailList;

            ICollection<Phone> phoneList = new List<Phone>();
            foreach (PhoneVM phoneNumbers in model.PhoneNumbers)
            {
                phoneList.Add(phoneNumbers.viewModelToPhone(phoneNumbers));
            }
            contact.PhoneNumbers = phoneList;                

            return contact;
        }
    }
}