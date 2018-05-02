namespace QLKFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityModels1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Objectsses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Count = c.Int(nullable: false),
                        DateAdded = c.DateTime(),
                        SuplierId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supliers", t => t.SuplierId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.SuplierId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Supliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        Addresss = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        MoreInfo = c.String(),
                        ContractDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objectsses", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Objectsses", "SuplierId", "dbo.Supliers");
            DropIndex("dbo.Objectsses", new[] { "UnitId" });
            DropIndex("dbo.Objectsses", new[] { "SuplierId" });
            DropTable("dbo.Units");
            DropTable("dbo.Supliers");
            DropTable("dbo.Objectsses");
        }
    }
}
