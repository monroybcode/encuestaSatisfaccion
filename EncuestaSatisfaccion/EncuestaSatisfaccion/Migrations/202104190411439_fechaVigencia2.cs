namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechaVigencia2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VigenciaEnc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dias = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        UserCap = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCap)
                .Index(t => t.UserCap);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VigenciaEnc", "UserCap", "dbo.AspNetUsers");
            DropIndex("dbo.VigenciaEnc", new[] { "UserCap" });
            DropTable("dbo.VigenciaEnc");
        }
    }
}
