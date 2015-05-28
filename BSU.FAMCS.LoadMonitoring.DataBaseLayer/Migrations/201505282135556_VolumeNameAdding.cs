namespace BSU.FAMCS.LoadMonitoring.DataBaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VolumeNameAdding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HddDisks", "VolumeLabel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HddDisks", "VolumeLabel");
        }
    }
}
