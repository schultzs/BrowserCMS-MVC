using System;

namespace BrowserCMS_MVC.Models.ViewModels
{
    /// <summary>
    /// Phone numbers tied to a contact
    /// </summary>
    public class PhoneVM
    {
        public int Id { get; set; }

        public PhoneType PhoneType { get; set; }
        
        public string PhoneNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public PhoneVM phoneToViewModel(Phone phone)
        {
            PhoneVM model = new PhoneVM
            {
                Id = phone.Id,
                PhoneType = phone.PhoneType,
                PhoneNumber = phone.PhoneNumber,
                DateCreated = phone.DateCreated,
                DateModified = phone.DateModified
            };

            return model;
        }

        public Phone viewModelToPhone(PhoneVM model)
        {
            Phone phone = new Phone
            {
                Id = model.Id,
                PhoneType = model.PhoneType,
                PhoneNumber = model.PhoneNumber,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified
            };

            return phone;
        }
    }
}