namespace PROG5ASSESMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedSomePropertiesRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kortings", "KortingsCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kortings", "KortingsCode", c => c.String());
        }
    }
}
