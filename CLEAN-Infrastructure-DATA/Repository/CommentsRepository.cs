using CLEAN_Domain.Interface;
using CLEAN_Domain.Models;
using CLEAN_Infrastructure_DATA.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CLEAN_Infrastructure_DATA.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        BaseRepository<CommentsModel, KnowledgeBaseContext> knowledgeBaseCommentDb;
        public CommentsRepository(KnowledgeBaseContext context)
        {
            knowledgeBaseCommentDb = new BaseRepository<CommentsModel, KnowledgeBaseContext>(context);
        }

        public Task<List<CommentsModel>> getComments(Guid KNOWLEDGE_BASE_ID)
        {
            var result = knowledgeBaseCommentDb.sqlConn.Query<CommentsModel>(@"
                SELECT * FROM ARTICLE_COMMENTS WHERE KNOWLEDGE_BASE_ID = @KNOWLEDGE_BASE_ID ORDER BY DATE_SUBMITTED ASC;  
            ", new { KNOWLEDGE_BASE_ID = KNOWLEDGE_BASE_ID }).AsList();
            return Task.FromResult(result);
        }
        public Task<CommentsModel> createComments(CommentsModel param_obj)
        {
            param_obj.COMMENTS_ID = Guid.NewGuid();
            param_obj.DATE_SUBMITTED = DateTime.Now;
            param_obj.STATUS = true;
            knowledgeBaseCommentDb.Insert(param_obj);
            return Task.FromResult(param_obj);
        }
    }
}
