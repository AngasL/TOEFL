namespace TOEFL.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(),
                        TPOName = c.String(),
                        ArticleType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            CreateTable(
                "dbo.Sentence",
                c => new
                    {
                        SentenceId = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.SentenceId)
                .ForeignKey("dbo.Article", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.SentenceVocabularyMapping",
                c => new
                    {
                        SentenceVocabularyMappingId = c.Int(nullable: false, identity: true),
                        SentenceId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        Vocabulary_VocabularyId = c.Int(),
                    })
                .PrimaryKey(t => t.SentenceVocabularyMappingId)
                .ForeignKey("dbo.Sentence", t => t.SentenceId, cascadeDelete: true)
                .ForeignKey("dbo.Vocabulary", t => t.Vocabulary_VocabularyId)
                .Index(t => t.SentenceId)
                .Index(t => t.Vocabulary_VocabularyId);
            
            CreateTable(
                "dbo.Vocabulary",
                c => new
                    {
                        VocabularyId = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Content = c.String(),
                        frequency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VocabularyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sentence", "ArticleId", "dbo.Article");
            DropForeignKey("dbo.SentenceVocabularyMapping", "Vocabulary_VocabularyId", "dbo.Vocabulary");
            DropForeignKey("dbo.SentenceVocabularyMapping", "SentenceId", "dbo.Sentence");
            DropIndex("dbo.SentenceVocabularyMapping", new[] { "Vocabulary_VocabularyId" });
            DropIndex("dbo.SentenceVocabularyMapping", new[] { "SentenceId" });
            DropIndex("dbo.Sentence", new[] { "ArticleId" });
            DropTable("dbo.Vocabulary");
            DropTable("dbo.SentenceVocabularyMapping");
            DropTable("dbo.Sentence");
            DropTable("dbo.Article");
        }
    }
}
