namespace BrowserCMS_MVC.Migrations
{
    using BrowserCMS_MVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BrowserCMS_MVC.DAL.CompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BrowserCMS_MVC.DAL.CompanyContext context)
        {
            context.EmailTypes.AddOrUpdate(
                new EmailType { Id = 1, EmailTypeName = "Work Email" },
                new EmailType { Id = 2, EmailTypeName = "Personal Email" }
                );

            context.SaveChanges();

            context.PhoneTypes.AddOrUpdate(
                new PhoneType { Id = 1, PhoneTypeName = "Work Phone" },
                new PhoneType { Id = 2, PhoneTypeName = "Cell Phone" },
                new PhoneType { Id = 3, PhoneTypeName = "Home Phone" }
                );

            context.SaveChanges();

            context.AddressTypes.AddOrUpdate(
                new AddressType { Id = 1, AddressTypeName = "Mailing Address" },
                new AddressType { Id = 2, AddressTypeName = "Billing Address" }
                );

            context.SaveChanges();

            List<Email> emails = new List<Email>
            {
                new Email { Id = 1, EmailAddress = "email@someaddress.com", DateCreated = DateTime.Parse("2013-12-04 13:10:02.000"), DateModified = DateTime.Parse("2013-12-05 15:15:25.000"), EmailType = context.EmailTypes.FirstOrDefault(x => x.Id == 2) },
                new Email { Id = 2, EmailAddress = "workemail@another.com", DateCreated = DateTime.Parse("2013-12-04 13:10:02.000"), DateModified = DateTime.Parse("2013-12-05 15:15:25.000"), EmailType = context.EmailTypes.FirstOrDefault(x => x.Id == 1) }
            };
            emails.ForEach(x => context.EmailAddresses.Add(x));

            List<Phone> phones = new List<Phone>
            {
                new Phone { Id = 1, PhoneNumber = "406-123-4567", DateCreated = DateTime.Parse("2013-12-04 13:10:02.000"), DateModified = DateTime.Parse("2013-12-05 15:15:25.000"), PhoneType = context.PhoneTypes.FirstOrDefault(x => x.Id == 1) },
                new Phone { Id = 2, PhoneNumber = "406-987-6543", DateCreated = DateTime.Parse("2013-12-04 13:10:02.000"), DateModified = DateTime.Parse("2013-12-05 15:15:25.000"), PhoneType = context.PhoneTypes.FirstOrDefault(x => x.Id == 2) }
            };
            phones.ForEach(x => context.PhoneNumbers.Add(x));

            List<Address> addresses = new List<Address>
            {
                new Address { Id = 1, AddressLine1 = "123 Some Street", City = "Bozeman", State = "MT", ZipCode = "59718", DateCreated = DateTime.Parse("2013-12-04 13:10:02.000"), DateModified = DateTime.Parse("2013-12-04 13:10:02.000"), AddressType = context.AddressTypes.FirstOrDefault(x => x.Id == 1) },
                new Address { Id = 2, AddressLine1 = "456 Another St.", City = "Bozeman", State = "MT", ZipCode = "59715", DateCreated = DateTime.Parse("2013-12-04 13:10:02.000"), DateModified = DateTime.Parse("2013-12-04 13:10:02.000"), AddressType = context.AddressTypes.FirstOrDefault(x => x.Id == 2) }
            };
            addresses.ForEach(x => context.Addresses.Add(x));

            Company company = new Company { Id = 1, Name = "Default Company", DateCreated = DateTime.Parse("2013-12-04 13:10:02.000"), DateModified = DateTime.Parse("2013-12-05 15:15:25.000"), Contacts = new List<Contact>() };
            Contact contact = new Contact { Id = 1, FirstName = "First", LastName = "Last", DateCreated = DateTime.Parse("2013-12-04 13:10:02.000"), DateModified = DateTime.Parse("2013-12-04 13:10:02.000"), DateLastContacted = DateTime.Parse("2013-12-04 13:10:02.000"), EmailAddresses = new List<Email>(), PhoneNumbers = new List<Phone>(), Addresses = new List<Address>() };

            contact.EmailAddresses.Add(emails[0]);
            contact.EmailAddresses.Add(emails[1]);
            contact.PhoneNumbers.Add(phones[0]);
            contact.PhoneNumbers.Add(phones[1]);
            contact.Addresses.Add(addresses[0]);
            contact.Addresses.Add(addresses[1]);
            company.Contacts.Add(contact);
            context.Companies.Add(company);
            context.SaveChanges();
        }
    }
}
