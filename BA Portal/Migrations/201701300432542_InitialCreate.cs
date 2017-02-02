namespace BA_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        GenderISfemale = c.Boolean(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        ZIP = c.Int(nullable: false),
                        PhoneHome = c.String(),
                        PhoneCell = c.String(),
                        Email = c.String(),
                        EmergencyContact = c.String(),
                        EmergencyContactPhone = c.String(),
                        EmergencyContactRelationship = c.String(),
                        ReferredBy = c.String(),
                        PatiendID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
