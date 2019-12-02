namespace GeolocationWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeoLocalizations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ip = c.String(),
                        url = c.String(),
                        city = c.String(),
                        region = c.String(),
                        country = c.String(),
                        loc = c.String(),
                        org = c.String(),
                        postal = c.String(),
                        timezone = c.String(),
                        readme = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeoLocalizations");
        }
    }
}
