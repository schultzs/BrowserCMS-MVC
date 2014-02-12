using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace BrowserCMS_MVC.Models
{
    /// <summary>
    /// Physical addresses tied to a contact
    /// </summary>
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public virtual Contact Contact { get; set; }

        public virtual AddressType AddressType { get; set; }
        
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }

    /// <summary>
    /// Defines the physical address types
    /// </summary>
    public class AddressType
    {
        public int Id { get; set; }
        public string AddressTypeName { get; set; }
    }
}