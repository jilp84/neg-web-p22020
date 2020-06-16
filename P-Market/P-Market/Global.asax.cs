using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using P_Market.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace P_Market
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<P_Market.Data.P_MarketContext,
                P_Market.Migrations.Configuration>());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Iniciar base de datos
            ApplicationDbContext db = new ApplicationDbContext();

            CreateRoles(db);
            CreateUsers(db);
            AddPermisionsToUser(db);

        }

        private void CreateRoles(ApplicationDbContext db) {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //Definir rol admin
            if (!roleManager.RoleExists("admin"))
            {
                roleManager.Create(new IdentityRole("admin"));
            }

        }

        private void CreateUsers(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByEmail("admin@me.com");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "admin@me.com",
                    Email = "admin@me.com"
                };
                userManager.Create(user, "Admin2020*");

            }
        }

        private void AddPermisionsToUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByEmail("admin@me.com");

            if (!userManager.IsInRole(user.Id, "admin"))
            {
                userManager.AddToRole(
                    user.Id,
                    "admin"
                );
            }

        }

    }
}
