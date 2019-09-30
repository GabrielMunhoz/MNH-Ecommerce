using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Repository.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MNH_Ecommerce.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly MNH_EcommerceContext MnhEcommerceContext;

        public BaseRepository(MNH_EcommerceContext mnh_EcommerceContext)
        {
            MnhEcommerceContext = mnh_EcommerceContext;
        }

        public void Add(TEntity entity)
        {
            try
            {
                MnhEcommerceContext.Set<TEntity>().Add(entity);
                MnhEcommerceContext.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void Delete(TEntity entity)
        {
            MnhEcommerceContext.Remove(entity);
            MnhEcommerceContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return MnhEcommerceContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return MnhEcommerceContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            MnhEcommerceContext.Set<TEntity>().Update(entity);
            MnhEcommerceContext.SaveChanges();
        }
        public void Dispose()
        {
            MnhEcommerceContext.Dispose();
        }
    }
}
