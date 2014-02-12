using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace BrowserCMS_MVC.Models
{
    /// <summary>
    /// Email addresses tied to a contact
    /// </summary>
    public class Email
    {
        public int Id { get; set; }

        [Required]
        public virtual Contact Contact { get; set; }

        public virtual EmailType EmailType { get; set; }
        
        public string EmailAddress { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }

    /// <summary>
    /// Defines the email types
    /// </summary>
    public class EmailType
    {
        public int Id { get; set; }
        public string EmailTypeName { get; set; }
    }
}