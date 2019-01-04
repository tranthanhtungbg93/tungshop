namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagsfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Tags");
        }
    }
}
