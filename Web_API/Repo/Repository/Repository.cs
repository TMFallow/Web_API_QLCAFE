using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repo.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> entities;

        private readonly QlCafe2Context context;

        public Repository(QlCafe2Context context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(string id)
        {
            return entities.Find(id);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                entities.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            else
            {
                entities.Add(entity);
                context.SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
