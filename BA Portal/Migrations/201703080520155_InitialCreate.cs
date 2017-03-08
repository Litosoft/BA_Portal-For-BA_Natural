namespace BA_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PDFs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SearchTag = c.String(),
                        PDFinbytes = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PDFs");
        }
    }
}
