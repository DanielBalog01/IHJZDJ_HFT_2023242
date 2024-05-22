using IHJZDJ_HFT_2023242.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHJZDJ_HFT_2023242.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DogDbContext DbCtx;

        public Repository(DogDbContext DbCtx)
        {
            this.DbCtx = DbCtx;
        }
        public void Create(T item)
        {
            DbCtx.Set<T>().Add(item);
            DbCtx.SaveChanges();
        }

        public void Delete(int id)
        {
            DbCtx.Set<T>().Remove(Read(id));
            DbCtx.SaveChanges();
        }
        

        public IQueryable<T> ReadAll()
        {
            return DbCtx.Set<T>();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);
       
    }
}
