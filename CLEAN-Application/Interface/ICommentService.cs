using CLEAN_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CLEAN_Application.Interface
{
    public interface ICommentService
    {
        Task<List<CommentsModel>> getComments(Guid KNOWLEDGE_BASE_ID);
        Task<CommentsModel> createComments(CommentsModel param_obj);
    }
}
