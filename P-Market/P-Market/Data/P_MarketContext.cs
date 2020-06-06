using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace P_Market.Data
{
    public class P_MarketContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public P_MarketContext() : base("name=P_MarketContext")
        {
        }

        public System.Data.Entity.DbSet<P_Market.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<P_Market.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<P_Market.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<P_Market.Models.IdentifitationType> IdentifitationTypes { get; set; }

        public System.Data.Entity.DbSet<P_Market.Models.Client> Clients { get; set; }
    }
}
