using BrowserCMS_MVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BrowserCMS_MVC.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("BrowserCMSDB")
        {
        }
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> PhoneNumbers { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<EmailType> EmailTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}