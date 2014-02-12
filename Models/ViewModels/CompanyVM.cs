using System;
using System.Collections.Generic;

namespace BrowserCMS_MVC.Models.ViewModels
{
    /// <summary>
    /// Phone numbers tied to a contact
    /// </summary>
    public class CompanyVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public CompanyVM companyToViewModel(Company company)
        {
            CompanyVM model = new CompanyVM
            {
                Id = company.Id,
                Name = company.Name,
                Contacts = company.Contacts,
                DateCreated = company.DateCreated,
                DateModified = company.DateModified
            };

            return model;
        }

        public Company viewModelToCompany(CompanyVM model)
        {
            Company company = new Company
            {
                Id = model.Id,
                Name = model.Name,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified
            };

            return company;
        }
    }
}