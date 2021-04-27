namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encuestados", "Borrado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Encuestados", "Borrado");
        }
    }
}
