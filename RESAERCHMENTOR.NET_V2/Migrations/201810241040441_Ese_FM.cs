namespace RESAERCHMENTOR.NET_V2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Ese_FM : DbMigration
    {
        public override void Up()
        {


            CreateTable(
                "dbo.UserProfiles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FullName = c.String(),
                    Title = c.String(),
                    FName = c.String(),
                    LName = c.String(),
                    Degree = c.String(),
                    CNumber = c.String(),
                    BDate = c.String(),
                    Gender = c.String(),
                    OwnersId = c.String(),
                    DateCreated = c.String(),
                    ConfirmationCode = c.String(),
                    ProfilePics = c.Binary(),
                    ProfilePicsName = c.String(),
                    FollowState = c.String(),
                    IsConfirmed = c.Boolean(nullable: false),
                    Gender1 = c.Boolean(nullable: false),
                    Gender2 = c.Boolean(nullable: false),
                    Country = c.String(),
                    WhoYouAre = c.String(),
                    Institution = c.String(),
                    Qualification = c.String(),
                    Expertise = c.String(),
                    Specialty = c.String(),
                    Interest = c.String(),
                    fieldExpertise = c.String(),
                    WillingToBe = c.String(),
                    MentorCategory = c.String(),
                })
                .PrimaryKey(t => t.Id);



        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Researches");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Messages");
            DropTable("dbo.MenTors_Mentees");
            DropTable("dbo.Followers");
            DropTable("dbo.Activities");
        }
    }
}
