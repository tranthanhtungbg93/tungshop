namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addquantityforproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Quantity", c => c.Int());
			Sql("update dbo.Product set Quantity =0");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Quantity");
        }
    }
}
