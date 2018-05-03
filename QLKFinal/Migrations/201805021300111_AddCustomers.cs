namespace QLKFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        PhoneNumber = c.String(),
                        DateOfBirt = c.DateTime(),
                        Email = c.String(),
                        Adresss = c.String(),
                        MoreInfo = c.String(),
                        ContracDate = c.DateTime(),
                        SuplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supliers", t => t.SuplierId, cascadeDelete: true)
                .Index(t => t.SuplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "SuplierId", "dbo.Supliers");
            DropIndex("dbo.Customers", new[] { "SuplierId" });
            DropTable("dbo.Customers");
        }
    }
}
