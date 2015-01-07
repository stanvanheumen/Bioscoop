namespace PROG5ASSESMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        TijdsduurInMinuten = c.Int(nullable: false),
                        Naam = c.String(nullable: false),
                        Prijs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatumEnTijd = c.DateTime(nullable: false),
                        Zaal_ZaalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId)
                .ForeignKey("dbo.Zaals", t => t.Zaal_ZaalId, cascadeDelete: true)
                .Index(t => t.Zaal_ZaalId);
            
            CreateTable(
                "dbo.Reserverings",
                c => new
                    {
                        ReserveringId = c.Int(nullable: false, identity: true),
                        Totaalprijs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Factuuradres = c.String(),
                        Bankrekeningnummer = c.String(),
                        KortingsCode = c.String(),
                        Film_FilmId = c.Int(nullable: false),
                        Korting_KortingId = c.Int(),
                    })
                .PrimaryKey(t => t.ReserveringId)
                .ForeignKey("dbo.Films", t => t.Film_FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Kortings", t => t.Korting_KortingId)
                .Index(t => t.Film_FilmId)
                .Index(t => t.Korting_KortingId);
            
            CreateTable(
                "dbo.Gasts",
                c => new
                    {
                        GastId = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(nullable: false),
                        TussenVoegsel = c.String(),
                        Achternaam = c.String(nullable: false),
                        Reservering_ReserveringId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GastId)
                .ForeignKey("dbo.Reserverings", t => t.Reservering_ReserveringId, cascadeDelete: true)
                .Index(t => t.Reservering_ReserveringId);
            
            CreateTable(
                "dbo.Kortings",
                c => new
                    {
                        KortingId = c.Int(nullable: false, identity: true),
                        KortingsCode = c.String(),
                        Kortingsprijs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDatum = c.DateTime(nullable: false),
                        EindDatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KortingId);
            
            CreateTable(
                "dbo.Zaals",
                c => new
                    {
                        ZaalId = c.Int(nullable: false, identity: true),
                        Zitplaatsen = c.Int(nullable: false),
                        Naam = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ZaalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Zaal_ZaalId", "dbo.Zaals");
            DropForeignKey("dbo.Reserverings", "Korting_KortingId", "dbo.Kortings");
            DropForeignKey("dbo.Gasts", "Reservering_ReserveringId", "dbo.Reserverings");
            DropForeignKey("dbo.Reserverings", "Film_FilmId", "dbo.Films");
            DropIndex("dbo.Films", new[] { "Zaal_ZaalId" });
            DropIndex("dbo.Reserverings", new[] { "Korting_KortingId" });
            DropIndex("dbo.Gasts", new[] { "Reservering_ReserveringId" });
            DropIndex("dbo.Reserverings", new[] { "Film_FilmId" });
            DropTable("dbo.Zaals");
            DropTable("dbo.Kortings");
            DropTable("dbo.Gasts");
            DropTable("dbo.Reserverings");
            DropTable("dbo.Films");
        }
    }
}
