namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datosencuestados : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encuestados", "fechaAlta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Encuestados", "UserCap", c => c.String(maxLength: 128));
            CreateIndex("dbo.Encuestados", "UserCap");
            AddForeignKey("dbo.Encuestados", "UserCap", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Encuestados", "UserCap", "dbo.AspNetUsers");
            DropIndex("dbo.Encuestados", new[] { "UserCap" });
            DropColumn("dbo.Encuestados", "UserCap");
            DropColumn("dbo.Encuestados", "fechaAlta");
        }
    }
}
