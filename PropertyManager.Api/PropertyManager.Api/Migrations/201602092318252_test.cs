namespace PropertyManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "State", c => c.String());
            DropColumn("dbo.Addresses", "Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Region", c => c.String());
            DropColumn("dbo.Addresses", "State");
        }
    }
}
