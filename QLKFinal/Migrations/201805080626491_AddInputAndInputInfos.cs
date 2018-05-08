namespace QLKFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInputAndInputInfos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InputInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(),
                        InputPrice = c.Single(nullable: false),
                        OutputPrice = c.Single(nullable: false),
                        Status = c.String(),
                        ObjectssId = c.Int(nullable: false),
                        InputId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inputs", t => t.InputId, cascadeDelete: true)
                .ForeignKey("dbo.Objectsses", t => t.ObjectssId, cascadeDelete: true)
                .Index(t => t.ObjectssId)
                .Index(t => t.InputId);
            
            CreateTable(
                "dbo.Inputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InputInfoes", "ObjectssId", "dbo.Objectsses");
            DropForeignKey("dbo.InputInfoes", "InputId", "dbo.Inputs");
            DropIndex("dbo.InputInfoes", new[] { "InputId" });
            DropIndex("dbo.InputInfoes", new[] { "ObjectssId" });
            DropTable("dbo.Inputs");
            DropTable("dbo.InputInfoes");
        }
    }
}
