using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace BrowserCMS_MVC.Models
{
    /// <summary>
    /// Phone numbers tied to a contact
    /// </summary>
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        public virtual Contact Contact { get; set; }
        
        public virtual PhoneType PhoneType { get; set; }
        
        public string PhoneNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }

    /// <summary>
    /// Defines the phone types
    /// </summary>
    public class PhoneType
    {
        public int Id { get; set; }
        public string PhoneTypeName { get; set; }
    }
}