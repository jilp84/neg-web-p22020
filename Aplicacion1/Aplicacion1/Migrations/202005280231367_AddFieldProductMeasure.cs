namespace Aplicacion1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldProductMeasure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductMeasure", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductMeasure");
        }
    }
}
