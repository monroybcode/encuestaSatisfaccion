namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class respFaltantes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Respuestas", "rp17", c => c.String());
            AddColumn("dbo.Respuestas", "rp18", c => c.String());
            AddColumn("dbo.Respuestas", "rp19", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Respuestas", "rp19");
            DropColumn("dbo.Respuestas", "rp18");
            DropColumn("dbo.Respuestas", "rp17");
        }
    }
}
