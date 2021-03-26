using CLEAN_Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CLEAN_Domain.Interface
{
    public interface IKnowledgeBaseRepository
    {
        Task<List<ArticleModel>> get();
        Task<string> getDescription(Guid KnowledgeBaseNumber);
        Task<ArticleModel> create(ArticleModel param_obj);
        Task<bool> update(ArticleModel param_obj);
        Task<bool> delete(Guid param_obj);
    }
}
