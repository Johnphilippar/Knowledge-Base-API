using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CLEAN_Domain.Models
{
    public class CommentsModel
    {
        [Key]
        public Guid COMMENTS_ID { get; set; }
        public Guid KNOWLEDGE_BASE_ID { get; set; }
        public string COMMENTS { get; set; }
        public string COMMENT_BY { get; set; }

        public DateTime DATE_SUBMITTED { get; set; }

        public bool STATUS { get; set; }
    }
}
                                                                                           