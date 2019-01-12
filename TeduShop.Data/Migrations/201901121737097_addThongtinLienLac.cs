namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addThongtinLienLac : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThongTinLienLac",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenLienLac = c.String(nullable: false, maxLength: 250),
                        SoDienThoai = c.String(maxLength: 50),
                        EmailLienLac = c.String(maxLength: 250),
                        WebSiteLienLac = c.String(maxLength: 250),
                        AddressLienLac = c.String(maxLength: 250),
                        OtherLienLac = c.String(),
                        LatLienLac = c.Double(),
                        LgnLienLac = c.Double(),
                        TrangThai = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContactDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 250),
                        WebSite = c.String(maxLength: 250),
                        Address = c.String(maxLength: 250),
                        Other = c.String(),
                        Lat = c.Double(),
                        Lgn = c.Double(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
