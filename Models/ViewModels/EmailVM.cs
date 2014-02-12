using System;

namespace BrowserCMS_MVC.Models.ViewModels
{
    /// <summary>
    /// View model for an email address
    /// </summary>
    public class EmailVM
    {
        public int Id { get; set; }

        public EmailType EmailType { get; set; }
        
        public string EmailAddress { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public EmailVM emailToViewModel(Email email)
        {
            EmailVM model = new EmailVM
            {
                Id = email.Id,
                EmailType = email.EmailType,
                EmailAddress = email.EmailAddress,
                DateCreated = email.DateCreated,
                DateModified = email.DateModified
            };

            return model;
        }

        public Email viewModelToEmail(EmailVM model)
        {
            Email email = new Email
            {
                Id = model.Id,
                EmailType = model.EmailType,
                EmailAddress = model.EmailAddress,
                DateCreated = model.DateCreated,
                DateModified = model.DateModified
            };

            return email;
        }
    }
}