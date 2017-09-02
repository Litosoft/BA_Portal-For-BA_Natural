namespace BA_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherDescription_Subjects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "OtherDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "OtherDescription");
        }
    }
}
