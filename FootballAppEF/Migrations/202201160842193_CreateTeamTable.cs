﻿namespace FootballAppEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTeamTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Position = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
