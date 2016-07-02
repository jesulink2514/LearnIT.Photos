namespace LearnIT.Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MimeTypeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "MimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "MimeType");
        }
    }
}
