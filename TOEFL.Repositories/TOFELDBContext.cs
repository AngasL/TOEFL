using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TOEFL.Repository.Models;

namespace TOEFL.Repositories
{
    public class TOFELDBContext : DbContext
    {
        public TOFELDBContext() : base("TOFELDBContext")
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Vocabulary> Vocabularies { get; set; }
        public DbSet<SentenceVocabularyMapping> SentenceVocabularyMappings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<Sentence>().ToTable("Sentence");
            modelBuilder.Entity<Vocabulary>().ToTable("Vocabulary");
            modelBuilder.Entity<SentenceVocabularyMapping>().ToTable("SentenceVocabularyMapping");

            base.OnModelCreating(modelBuilder);
        }
    }
}
