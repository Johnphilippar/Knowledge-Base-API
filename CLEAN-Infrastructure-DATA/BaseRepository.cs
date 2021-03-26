using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLEAN_Infrastructure_DATA
{
    public class BaseRepository<T , TContext> where T : class
    {
        protected TContext context;
        public DbSet<T> dbSet;
        public SqlConnection sqlConn;

        public BaseRepository(TContext context)
        {
            this.context = context;
            this.dbSet = (context as DbContext).Set<T>();
            this.sqlConn = (context as DbContext).Database.GetDbConnection() as SqlConnection;
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
            (context as DbContext).SaveChanges();
        }
        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
            (context as DbContext).SaveChanges();
        }
        public virtual void Delete(Guid KNOWLEDGE_BASE_ID)
        {
            T entityDelete = dbSet.Find(KNOWLEDGE_BASE_ID);
            if (entityDelete != null)
                dbSet.Remove(entityDelete);
            (context as DbContext).SaveChanges();
        }

    }
}
