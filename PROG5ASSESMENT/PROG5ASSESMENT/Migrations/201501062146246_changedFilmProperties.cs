namespace PROG5ASSESMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedFilmProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "StartDatumMetTijd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Films", "EindDatumMetTijd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Films", "TijdsduurInMinuten");
            DropColumn("dbo.Films", "DatumEnTijd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "DatumEnTijd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Films", "TijdsduurInMinuten", c => c.Int(nullable: false));
            DropColumn("dbo.Films", "EindDatumMetTijd");
            DropColumn("dbo.Films", "StartDatumMetTijd");
        }
    }
}
