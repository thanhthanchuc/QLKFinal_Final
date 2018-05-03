namespace QLKFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReqToObject : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Objectsses", "DisplayName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Objectsses", "DisplayName", c => c.String());
        }
    }
}
