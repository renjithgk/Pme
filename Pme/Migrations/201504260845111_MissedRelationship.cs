namespace Pme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MissedRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PmeDetails", "Pme_PmeId", "dbo.Pmes");
            DropIndex("dbo.PmeDetails", new[] { "Pme_PmeId" });
            RenameColumn(table: "dbo.PmeDetails", name: "Pme_PmeId", newName: "PmeId");
            AlterColumn("dbo.PmeDetails", "PmeId", c => c.Int(nullable: false));
            CreateIndex("dbo.PmeDetails", "PmeId");
            AddForeignKey("dbo.PmeDetails", "PmeId", "dbo.Pmes", "PmeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PmeDetails", "PmeId", "dbo.Pmes");
            DropIndex("dbo.PmeDetails", new[] { "PmeId" });
            AlterColumn("dbo.PmeDetails", "PmeId", c => c.Int());
            RenameColumn(table: "dbo.PmeDetails", name: "PmeId", newName: "Pme_PmeId");
            CreateIndex("dbo.PmeDetails", "Pme_PmeId");
            AddForeignKey("dbo.PmeDetails", "Pme_PmeId", "dbo.Pmes", "PmeId");
        }
    }
}
