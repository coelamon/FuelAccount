using FuelAccount.Util;
using NHibernate;
using System.Collections.Generic;

namespace FuelAccount.Repository
{
    public class NHibernateRepository<TEntity, TKey> where TEntity : class
    {
        public TEntity Get(TKey id)
        {
            using (ISession session = NHibernateSessionFactory.OpenSession())
            {
                TEntity entity = session.Get<TEntity>(id);
                return entity;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (ISession session = NHibernateSessionFactory.OpenSession())
            {
                IEnumerable<TEntity> entities = session.QueryOver<TEntity>().List();
                return entities;
            }
        }
    }
}
