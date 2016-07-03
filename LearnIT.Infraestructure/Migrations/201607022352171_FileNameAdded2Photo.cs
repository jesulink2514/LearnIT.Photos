namespace LearnIT.Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileNameAdded2Photo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "FileName");
        }
    }
}
