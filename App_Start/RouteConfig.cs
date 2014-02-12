using System.Web.Mvc;
using System.Web.Routing;

namespace BrowserCMS_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Company_Create",
                url: "Company/Create",
                defaults: new { controller = "Company", action = "Create" }
            );

            routes.MapRoute(
                name: "Contact_Edit",
                url: "Company/{id}/Contact/{contactId}/Edit",
                defaults: new { controller = "Contact", action = "Edit" }
            );

            routes.MapRoute(
                name: "Contact_Create",
                url: "Company/{id}/Contact/Create",
                defaults: new { controller = "Contact", action = "Create" }
            );

            routes.MapRoute(
                name: "Contact_Details",
                url: "Company/{id}/Contact/{contactId}",
                defaults: new { controller = "Contact", action = "Details" }
            );

            routes.MapRoute(
                name: "Contact_List",
                url: "Company/{id}/Contact",
                defaults: new { controller = "Contact", action = "Index" }
            );

            routes.MapRoute(
                name: "Company_Details",
                url: "Company/{id}",
                defaults: new { controller = "Company", action = "Details" }
            );

            routes.MapRoute(
                name: "Company_Edit",
                url: "Company/Edit/{id}",
                defaults: new { controller = "Company", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AddressType_Add",
                url: "Type/Address/Edit/",
                defaults: new { controller = "Type", action = "AddressAdd" }
            );
            routes.MapRoute(
                name: "AddressType_Edit",
                url: "Type/Address/Edit/{id}",
                defaults: new { controller = "Type", action = "AddressEdit" }
            );
            routes.MapRoute(
                name: "AddressType_Delete",
                url: "Type/Address/Delete/{id}",
                defaults: new { controller = "Type", action = "AddressDelete" }
            );

            routes.MapRoute(
                name: "EmailType_Add",
                url: "Type/Email/Edit",
                defaults: new { controller = "Type", action = "EmailAdd" }
            );
            routes.MapRoute(
                name: "EmailType_Edit",
                url: "Type/Email/Edit/{id}",
                defaults: new { controller = "Type", action = "EmailEdit" }
            );
            routes.MapRoute(
                name: "EmailType_Delete",
                url: "Type/Email/Delete/{id}",
                defaults: new { controller = "Type", action = "EmailDelete" }
            );

            routes.MapRoute(
                name: "PhoneType_Add",
                url: "Type/Phone/Edit",
                defaults: new { controller = "Type", action = "PhoneAdd" }
            );
            routes.MapRoute(
                name: "PhoneType_Edit",
                url: "Type/Phone/Edit/{id}",
                defaults: new { controller = "Type", action = "PhoneCreate" }
            );
            routes.MapRoute(
                name: "PhoneType_Delete",
                url: "Type/Phone/Delete/{id}",
                defaults: new { controller = "Type", action = "PhoneDelete" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
