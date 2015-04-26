namespace Pme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PmeDetails",
                c => new
                    {
                        PmeDetailId = c.Int(nullable: false, identity: true),
                        Threshold = c.String(),
                        Cpu = c.String(),
                        Clocking = c.String(),
                        Maximum = c.String(),
                        Minimum = c.String(),
                        Memory = c.String(),
                        Pme_PmeId = c.Int(),
                    })
                .PrimaryKey(t => t.PmeDetailId)
                .ForeignKey("dbo.Pmes", t => t.Pme_PmeId)
                .Index(t => t.Pme_PmeId);
            
            CreateTable(
                "dbo.Pmes",
                c => new
                    {
                        PmeId = c.Int(nullable: false, identity: true),
                        AppMapPackageId = c.String(),
                        Version = c.String(),
                        ProgrameCode = c.String(),
                        ProgrameVersionCode = c.String(),
                    })
                .PrimaryKey(t => t.PmeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PmeDetails", "Pme_PmeId", "dbo.Pmes");
            DropIndex("dbo.PmeDetails", new[] { "Pme_PmeId" });
            DropTable("dbo.Pmes");
            DropTable("dbo.PmeDetails");
        }
    }
}
