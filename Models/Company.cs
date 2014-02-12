using System;
using System.Collections.Generic;

namespace BrowserCMS_MVC.Models
{
    /// <summary>
    /// Company information
    /// </summary>
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}