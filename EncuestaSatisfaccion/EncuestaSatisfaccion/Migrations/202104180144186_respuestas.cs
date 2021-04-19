namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class respuestas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Respuestas", "rp1", c => c.String());
            AddColumn("dbo.Respuestas", "rp2", c => c.String());
            AddColumn("dbo.Respuestas", "rp3", c => c.String());
            AddColumn("dbo.Respuestas", "rp4", c => c.String());
            AddColumn("dbo.Respuestas", "rp5", c => c.String());
            AddColumn("dbo.Respuestas", "rp6", c => c.String());
            AddColumn("dbo.Respuestas", "rp7", c => c.String());
            AddColumn("dbo.Respuestas", "rp8", c => c.String());
            AddColumn("dbo.Respuestas", "rp9", c => c.String());
            AddColumn("dbo.Respuestas", "rp10", c => c.String());
            AddColumn("dbo.Respuestas", "rp11", c => c.String());
            AddColumn("dbo.Respuestas", "rp12", c => c.String());
            AddColumn("dbo.Respuestas", "rp13", c => c.String());
            AddColumn("dbo.Respuestas", "rp14", c => c.String());
            AddColumn("dbo.Respuestas", "rp15", c => c.String());
            AddColumn("dbo.Respuestas", "rp16", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Respuestas", "rp16");
            DropColumn("dbo.Respuestas", "rp15");
            DropColumn("dbo.Respuestas", "rp14");
            DropColumn("dbo.Respuestas", "rp13");
            DropColumn("dbo.Respuestas", "rp12");
            DropColumn("dbo.Respuestas", "rp11");
            DropColumn("dbo.Respuestas", "rp10");
            DropColumn("dbo.Respuestas", "rp9");
            DropColumn("dbo.Respuestas", "rp8");
            DropColumn("dbo.Respuestas", "rp7");
            DropColumn("dbo.Respuestas", "rp6");
            DropColumn("dbo.Respuestas", "rp5");
            DropColumn("dbo.Respuestas", "rp4");
            DropColumn("dbo.Respuestas", "rp3");
            DropColumn("dbo.Respuestas", "rp2");
            DropColumn("dbo.Respuestas", "rp1");
        }
    }
}
