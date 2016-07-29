namespace SimpleBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        DescricaoCurta = c.String(maxLength: 200),
                        Descricao = c.String(),
                        Meta = c.String(nullable: false, maxLength: 1000),
                        UrlSlug = c.String(nullable: false, maxLength: 200),
                        Publicado = c.Boolean(nullable: false),
                        DataPublicacao = c.DateTime(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        UrlSlug = c.String(nullable: false, maxLength: 50),
                        Descricao = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostsTags",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UrlSlug = c.String(),
                        Descricao = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostsTags", "TagId", "dbo.Tag");
            DropForeignKey("dbo.PostsTags", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.PostsTags", new[] { "TagId" });
            DropIndex("dbo.PostsTags", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "CategoriaId" });
            DropTable("dbo.Tag");
            DropTable("dbo.PostsTags");
            DropTable("dbo.Categoria");
            DropTable("dbo.Post");
        }
    }
}
