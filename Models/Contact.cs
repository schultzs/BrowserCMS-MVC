using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace BrowserCMS_MVC.Models
{
    /// <summary>
    /// Contact information tied to a company
    /// </summary>
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public virtual Company Company { get; set; }

        [Required, StringLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(40), Display(Name = "Last Name")]
        public string LastName { get; set; }

        public virtual ICollection<Phone> PhoneNumbers { get; set; }

        public virtual ICollection<Email> EmailAddresses { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public DateTime DateLastContacted { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}