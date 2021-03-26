using CLEAN_Domain.Interface;
using CLEAN_Domain.Models;
using CLEAN_Infrastructure_DATA.Context;
using Dapper;
using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CLEAN_Domain.Business;
using System.IO;

namespace CLEAN_Infrastructure_DATA.Repository
{
    public class KnowledgeBaseRepository : IKnowledgeBaseRepository
    {
        BaseRepository<ArticleModel, KnowledgeBaseContext> knowledgeBaseDb;

        public KnowledgeBaseRepository(KnowledgeBaseContext context)
        {
            knowledgeBaseDb = new BaseRepository<ArticleModel, KnowledgeBaseContext>(context);
        }

        public Task<List<ArticleModel>> get()
        {
            var result = knowledgeBaseDb.sqlConn.Query<ArticleModel>(@"
                SELECT * , 'KB' + REPLACE(STR(KNOWLEDGE_BASE_NUMBER,5), SPACE(1),'0') AS KNOWLEDGE_BASE_CODE
                FROM ARTICLE ORDER BY DATE_SUBMITTED DESC 
            ").AsList();
            return Task.FromResult(result);
        }
        public ArticleModel getKbData(Guid KNOWLEDGE_BASE_ID)
        {
            var result = knowledgeBaseDb.sqlConn.Query<ArticleModel>(@"
                SELECT* , 'KB' + REPLACE(STR(KNOWLEDGE_BASE_NUMBER,5), SPACE(1),'0') AS KNOWLEDGE_BASE_CODE
                FROM ARTICLE WHERE KNOWLEDGE_BASE_ID = @KNOWLEDGE_BASE_ID
            ", new { KNOWLEDGE_BASE_ID = KNOWLEDGE_BASE_ID }).FirstOrDefault();
            return result;
        }

        public Task<string> getDescription(Guid KnowledgeBaseNumber)
        {
            string kbpath = Environment.CurrentDirectory + "\\Article-File";
            string fileName = KnowledgeBaseNumber + ".txt";
            string createFile = kbpath + "/" + fileName;

            string text = FileIO.ReadText(createFile);
            return Task.FromResult(text);
        }

        public Task<ArticleModel> create(ArticleModel param_obj)
        {
            param_obj.KNOWLEDGE_BASE_ID = Guid.NewGuid();
            param_obj.DATE_SUBMITTED = DateTime.Now;

            string kbpath = Environment.CurrentDirectory + "\\Article-File";
            string fileName = param_obj.KNOWLEDGE_BASE_ID + ".txt";
            string createFile = kbpath + "/" + fileName;

            FileIO.CreateDirectory(kbpath);
            FileIO.CreateFile(createFile);
            FileIO.WriteText(param_obj.ARTICLE_DESCRIPTION, createFile);
            param_obj.ARTICLE_DESCRIPTION = "";


            knowledgeBaseDb.Insert(param_obj);
            param_obj = getKbData(param_obj.KNOWLEDGE_BASE_ID);
            return Task.FromResult(param_obj);
        }

        public Task<bool> update(ArticleModel param_obj)
        {
            string kbpath = Environment.CurrentDirectory + "\\Article-File";
            string fileName = param_obj.KNOWLEDGE_BASE_ID + ".txt";
            string createFile = kbpath + "/" + fileName;

            FileIO.CreateDirectory(kbpath);
            FileIO.CreateFile(createFile);
            FileIO.WriteText(param_obj.ARTICLE_DESCRIPTION, createFile);
            System.IO.File.WriteAllText(createFile, param_obj.ARTICLE_DESCRIPTION);
            param_obj.ARTICLE_DESCRIPTION = "";


            var updateArticle = knowledgeBaseDb.dbSet.FirstOrDefault(x => x.KNOWLEDGE_BASE_ID == param_obj.KNOWLEDGE_BASE_ID);
            updateArticle.ARTICLE_DESCRIPTION = param_obj.ARTICLE_DESCRIPTION;
            updateArticle.ARTICLE_TITLE = param_obj.ARTICLE_TITLE;
            updateArticle.KNOWLEDGE_BASE_NUMBER = param_obj.KNOWLEDGE_BASE_NUMBER;
            updateArticle.POSTED_BY = param_obj.POSTED_BY;

            param_obj.DATE_SUBMITTED = DateTime.Now;

            knowledgeBaseDb.Update(updateArticle);
            return Task.FromResult(true);
        }
        public Task<bool> delete(Guid param_obj)
        {
            knowledgeBaseDb.Delete(param_obj);
            return Task.FromResult(true);
        }
        
    }
}
