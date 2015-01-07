namespace PROG5ASSESMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedsomething : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reserverings", "Factuuradres", c => c.String(nullable: false));
            AlterColumn("dbo.Reserverings", "Bankrekeningnummer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reserverings", "Bankrekeningnummer", c => c.String());
            AlterColumn("dbo.Reserverings", "Factuuradres", c => c.String());
        }
    }
}
