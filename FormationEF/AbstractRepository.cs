using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationEF
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        public FormationEFEntities Entities { get ; set; }
        
        public virtual T GetById(int id)
        {           
            //Entities.Set<T>().FirstOrDefault(); // Renvoie null en cas de liste vide, le first souleve une Exception
            return Entities.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetByLambda(Func<T, bool> where)
        {
            return Entities.Set<T>().Where(where);
        }

        public virtual T Insert(T entity)
        {            
            Entities.Set<T>().Add(entity);
            return entity;         
        }

        public virtual void Remove(T entity)
        {           
            Entities.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {            
            Entities.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.Set<T>();
        }
                
        public virtual IEnumerable<T> GetByLambda(Func<T, bool> where, int page, int nbRow)
        {
            return Entities.Set<T>().Where(where).Take(nbRow).Skip(page-1*nbRow);
        }

    }
}
