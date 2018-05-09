namespace QLKFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfInput : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Inputs SET DisplayName = 'Phiếu nhập 1' WHERE Id = 1");
            Sql("UPDATE Inputs SET DisplayName = 'Phiếu nhập 2' WHERE Id = 2");
            Sql("UPDATE Inputs SET DisplayName = 'Phiếu nhập 3' WHERE Id = 3");
            Sql("UPDATE Inputs SET DisplayName = 'Phiếu nhập 4' WHERE Id = 4");

        }
        
        public override void Down()
        {
        }
    }
}
