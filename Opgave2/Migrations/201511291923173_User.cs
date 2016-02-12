namespace Opgave2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BrugerDatas", "HasProfile", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BrugerDatas", "Vaegt", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BrugerDatas", "Vaegt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.BrugerDatas", "HasProfile");
        }
    }
}
