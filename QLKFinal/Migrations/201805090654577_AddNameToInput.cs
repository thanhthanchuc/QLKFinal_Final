namespace QLKFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToInput : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inputs", "DisplayName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inputs", "DisplayName");
        }
    }
}
