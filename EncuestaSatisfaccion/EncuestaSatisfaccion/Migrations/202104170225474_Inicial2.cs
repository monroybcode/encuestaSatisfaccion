namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Encuestados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apa = c.String(),
                        Ama = c.String(),
                        mail = c.String(),
                        puesto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Respuestas",
                c => new
                    {
                        IdRegistro = c.Int(nullable: false, identity: true),
                        IdEncuestado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRegistro)
                .ForeignKey("dbo.Encuestados", t => t.IdEncuestado, cascadeDelete: true)
                .Index(t => t.IdEncuestado);
            
            AddColumn("dbo.UnidadesMedicas", "Consecutivo", c => c.Int(nullable: false));
           
        }
        
        public override void Down()
        {
            
            
            DropForeignKey("dbo.Respuestas", "IdEncuestado", "dbo.Encuestados");
            DropIndex("dbo.Respuestas", new[] { "IdEncuestado" });
            DropColumn("dbo.UnidadesMedicas", "Consecutivo");
            DropTable("dbo.Respuestas");
            DropTable("dbo.Encuestados");
        }
    }
}
