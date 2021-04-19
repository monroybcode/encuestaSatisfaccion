namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Ind_Activo = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Funciones",
                c => new
                    {
                        Id_Funcion = c.Int(nullable: false, identity: true),
                        NombreCorto = c.String(),
                        Nombre = c.String(),
                        Ind_Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Funcion);
            
            CreateTable(
                "dbo.FuncionesXRols",
                c => new
                    {
                        Id_FuncionesXRol = c.Int(nullable: false, identity: true),
                        Id_Funcion = c.Int(nullable: false),
                        Id_Rol = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id_FuncionesXRol)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Funciones", t => t.Id_Funcion, cascadeDelete: true)
                .Index(t => t.Id_Funcion)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UltimoIngreso = c.String(),
                        NombreCompleto = c.String(),
                        IndAct = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UnidadesMedicas",
                c => new
                    {
                        Id_UnidadMedica = c.Int(nullable: false, identity: true),
                        ClaveUnidad = c.Int(nullable: false),
                        UnidadMedica = c.String(),
                        active = c.Boolean(nullable: false),
                        Direccion = c.String(),
                        UsuarioJuridico = c.String(),
                        UsuarioCoordinador = c.String(),
                        Domicilio = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.Id_UnidadMedica);
            
            CreateTable(
                "dbo.UsuarioxUmedica",
                c => new
                    {
                        Id_UUN = c.Int(nullable: false, identity: true),
                        Id_unidad = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        FechaAlta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_UUN)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.UnidadesMedicas", t => t.Id_unidad, cascadeDelete: true)
                .Index(t => t.Id_unidad)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioxUmedica", "Id_unidad", "dbo.UnidadesMedicas");
            DropForeignKey("dbo.UsuarioxUmedica", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FuncionesXRols", "Id_Funcion", "dbo.Funciones");
            DropForeignKey("dbo.FuncionesXRols", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UsuarioxUmedica", new[] { "UserID" });
            DropIndex("dbo.UsuarioxUmedica", new[] { "Id_unidad" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.FuncionesXRols", new[] { "UserID" });
            DropIndex("dbo.FuncionesXRols", new[] { "Id_Funcion" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.UsuarioxUmedica");
            DropTable("dbo.UnidadesMedicas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.FuncionesXRols");
            DropTable("dbo.Funciones");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
