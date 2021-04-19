namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechacontesta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encuestados", "fechaContestado", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Encuestados", "fechaContestado");
        }
    }
}
