using System.Collections.Generic;

namespace TOEFL.Repository.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string TPOName { get; set; }
        public ArticleType ArticleType { get; set; }

        public virtual ICollection<Sentence> Sentences { get; set; }
    }

    public class Sentence
    {
        public int ArticleId { get; set; }
        public int SentenceId { get; set; }
        public string Content { get; set; }

        public virtual ICollection<SentenceVocabularyMapping> Mappings { get; set; }
    }

    public class Vocabulary
    {
        public int VocabularyId { get; set; }
        public int ArticleId { get; set; }
        public string Content { get; set; }
        public int frequency { get; set; }

        public virtual ICollection<SentenceVocabularyMapping> Mappings { get; set; }
    }

    public class SentenceVocabularyMapping
    {
        public int SentenceVocabularyMappingId { get; set; }
        public int SentenceId { get; set; }
        public int VocabularyId { get; set; }

        public virtual Sentence Sentence { get; set; }
        public virtual Vocabulary Vocabulary { get; set; }
    }

    public enum ArticleType
    {
        Unknow = 0,
        L = 1,
        C = 2,
    }
}
