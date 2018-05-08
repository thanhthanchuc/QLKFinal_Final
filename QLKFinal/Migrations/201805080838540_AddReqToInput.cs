namespace QLKFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReqToInput : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inputs", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inputs", "DateAdded", c => c.DateTime());
        }
    }
}
