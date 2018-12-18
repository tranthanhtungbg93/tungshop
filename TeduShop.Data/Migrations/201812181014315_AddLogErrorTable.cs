namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogErrorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogError",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        Massage = c.String(),
                        StackTrace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Posts", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Posts", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "MetaKeyWord", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Status");
            DropColumn("dbo.Posts", "MetaDescription");
            DropColumn("dbo.Posts", "MetaKeyWord");
            DropColumn("dbo.Posts", "UpdatedBy");
            DropColumn("dbo.Posts", "UpdatedDate");
            DropColumn("dbo.Posts", "CreatedBy");
            DropColumn("dbo.Posts", "CreatedDate");
            DropTable("dbo.LogError");
        }
    }
}
