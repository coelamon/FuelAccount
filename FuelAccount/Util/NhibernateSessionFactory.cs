using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelAccount.Util
{
    class NHibernateSessionFactory
    {
        private static ISessionFactory _sessionFactory;

        private static readonly object _factoryLock = new object();

        public static ISession OpenSession()
        {
            lock (_factoryLock)
            {
                if (_sessionFactory == null)
                {
                    var cfg = new Configuration().Configure();
                    _sessionFactory = cfg.BuildSessionFactory();
                }
            }
            return _sessionFactory.OpenSession();
        }
    }
}
