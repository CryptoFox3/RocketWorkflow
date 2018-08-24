namespace RocketWorkflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskNameToTasksMoel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "TaskName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "TaskName");
        }
    }
}
