using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrowserCMS_MVC.Models.ViewModels
{
    /// <summary>
    /// View model for a physical addresses
    /// </summary>
    public class AddressVM
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ContactId { get; set; }

        [Required, Display(Name = "Address Type")]
        public AddressType AddressType { get; set; }

        [Required, Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required, Display(Name = "City")]
        public string City { get; set; }

        [Required, Display(Name = "State")]
        public string State { get; set; }

        [Required, Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }

        public IEnumerable<AddressType> AddressTypeList { get; set; }

        public AddressVM addressToViewModel(Address address)
        {
            AddressVM model = new AddressVM
            {
                Id = address.Id,
                CompanyId = address.Contact.Company.Id,
                ContactId = address.Contact.Id,
                AddressType = address.AddressType,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode,
                DateCreated = address.DateCreated,
                DateModified = address.DateModified
            };

            return model;
        }

        public Address viewModelToAddress(AddressVM model)
        {
            Address address = new Address
            {
                Id = model.Id,
                AddressType = model.AddressType,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified
            };

            return address;
        }
    }
}