namespace TOEFL.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correct_the_ids_in_mapping_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SentenceVocabularyMapping", "Vocabulary_VocabularyId", "dbo.Vocabulary");
            DropIndex("dbo.SentenceVocabularyMapping", new[] { "Vocabulary_VocabularyId" });
            RenameColumn(table: "dbo.SentenceVocabularyMapping", name: "Vocabulary_VocabularyId", newName: "VocabularyId");
            AlterColumn("dbo.SentenceVocabularyMapping", "VocabularyId", c => c.Int(nullable: false));
            CreateIndex("dbo.SentenceVocabularyMapping", "VocabularyId");
            AddForeignKey("dbo.SentenceVocabularyMapping", "VocabularyId", "dbo.Vocabulary", "VocabularyId", cascadeDelete: true);
            DropColumn("dbo.SentenceVocabularyMapping", "ArticleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SentenceVocabularyMapping", "ArticleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SentenceVocabularyMapping", "VocabularyId", "dbo.Vocabulary");
            DropIndex("dbo.SentenceVocabularyMapping", new[] { "VocabularyId" });
            AlterColumn("dbo.SentenceVocabularyMapping", "VocabularyId", c => c.Int());
            RenameColumn(table: "dbo.SentenceVocabularyMapping", name: "VocabularyId", newName: "Vocabulary_VocabularyId");
            CreateIndex("dbo.SentenceVocabularyMapping", "Vocabulary_VocabularyId");
            AddForeignKey("dbo.SentenceVocabularyMapping", "Vocabulary_VocabularyId", "dbo.Vocabulary", "VocabularyId");
        }
    }
}
