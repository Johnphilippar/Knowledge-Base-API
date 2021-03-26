using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CLEAN_Domain.Models
{
    public class ArticleModel
    {
        [Key]
        public Guid KNOWLEDGE_BASE_ID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotMapped]
        public int KNOWLEDGE_BASE_NUMBER { get; set; }
        public string ARTICLE_TITLE { get; set; }
        public string POSTED_BY { get; set; }

        public DateTime DATE_SUBMITTED { get; set; } 
        public string ARTICLE_DESCRIPTION { get; set; }
        public List<string> ARTICLE_TAGS { get; set; }

        [NotMapped]
        
        public string KNOWLEDGE_BASE_CODE { get; set; }
    }
}
