using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrowserCMS_MVC.Models.ViewModels
{
    /// <summary>
    /// Used for admin work on the types of contact types.
    /// </summary>
    public class TypeVM
    {
        public IEnumerable<AddressType> addrTypes { get; set; }

        public IEnumerable<EmailType> emailTypes { get; set; }

        public IEnumerable<PhoneType> phoneTypes { get; set; }
    }
}