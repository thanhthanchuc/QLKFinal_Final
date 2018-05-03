namespace QLKFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreRequiredForAnyTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DisplayName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Supliers", "DisplayName", c => c.String(nullable: false));
            AlterColumn("dbo.Supliers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Supliers", "ContractDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Objectsses", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Units", "DisplayName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "DisplayName", c => c.String());
            AlterColumn("dbo.Objectsses", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Supliers", "ContractDate", c => c.DateTime());
            AlterColumn("dbo.Supliers", "Email", c => c.String());
            AlterColumn("dbo.Supliers", "DisplayName", c => c.String());
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Customers", "DisplayName", c => c.String());
        }
    }
}
