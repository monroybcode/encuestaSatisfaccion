namespace EncuestaSatisfaccion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campoContestado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encuestados", "Contestada", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Encuestados", "Contestada");
        }
    }
}
