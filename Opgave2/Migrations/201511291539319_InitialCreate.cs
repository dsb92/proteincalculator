namespace Opgave2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrugerDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrugerId = c.String(),
                        Vaegt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tilstand = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoedevareIndtags",
                c => new
                    {
                        ProteinKildeId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Maengde = c.Int(nullable: false),
                        PersonligListe_BrugerDataId = c.Int(),
                        PersonligListe_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.ProteinKildeId, t.Id })
                .ForeignKey("dbo.ProteinKildes", t => t.ProteinKildeId, cascadeDelete: true)
                .ForeignKey("dbo.PersonligListes", t => new { t.PersonligListe_BrugerDataId, t.PersonligListe_Id })
                .Index(t => t.ProteinKildeId)
                .Index(t => new { t.PersonligListe_BrugerDataId, t.PersonligListe_Id });
            
            CreateTable(
                "dbo.ProteinKildes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Navn = c.String(nullable: false),
                        Protein = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonligListes",
                c => new
                    {
                        BrugerDataId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Navn = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.BrugerDataId, t.Id })
                .ForeignKey("dbo.BrugerDatas", t => t.BrugerDataId, cascadeDelete: true)
                .Index(t => t.BrugerDataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoedevareIndtags", new[] { "PersonligListe_BrugerDataId", "PersonligListe_Id" }, "dbo.PersonligListes");
            DropForeignKey("dbo.PersonligListes", "BrugerDataId", "dbo.BrugerDatas");
            DropForeignKey("dbo.FoedevareIndtags", "ProteinKildeId", "dbo.ProteinKildes");
            DropIndex("dbo.PersonligListes", new[] { "BrugerDataId" });
            DropIndex("dbo.FoedevareIndtags", new[] { "PersonligListe_BrugerDataId", "PersonligListe_Id" });
            DropIndex("dbo.FoedevareIndtags", new[] { "ProteinKildeId" });
            DropTable("dbo.PersonligListes");
            DropTable("dbo.ProteinKildes");
            DropTable("dbo.FoedevareIndtags");
            DropTable("dbo.BrugerDatas");
        }
    }
}
