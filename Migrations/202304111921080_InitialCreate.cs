namespace MKR1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        NickName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.NickName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
