namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diasvig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encuestados", "DiasVig", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Encuestados", "DiasVig");
        }
    }
}
