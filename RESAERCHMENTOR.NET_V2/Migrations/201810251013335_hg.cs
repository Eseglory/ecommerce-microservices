namespace RESAERCHMENTOR.NET_V2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class hg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResearchTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id);



            CreateTable(
                "dbo.WhoYouAres",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Willings",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.WillingToes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.WillingToes");
            DropTable("dbo.Willings");
            DropTable("dbo.WhoYouAres");
            DropTable("dbo.Titles");
            DropTable("dbo.ResearchTypes");
        }
    }
}
