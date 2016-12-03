using System;
using System.Collections.Generic;
using FuelAccountModel.Domain;
using NHibernate;
using NHibernate.Linq;
using FuelAccount.Util;

namespace FuelAccount.Repository
{
    public class FuelBillRepository : NHibernateRepository<FuelBill, int>, IFuelBillRepository
    {
        public void Add(FuelBill entity)
        {
            using (ISession session = NHibernateSessionFactory.OpenSession())
            {
                if (IsDuplicate(session, entity))
                {
                    throw new Exception("duplicate");
                }
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        private bool IsDuplicate(ISession session, FuelBill entity)
        {
            bool isDuplicate = false;
            if (entity.BillTime != null)
            {
                isDuplicate |= session.QueryOver<FuelBill>()
                                      .Where(x => x.BillDate == entity.BillDate && x.BillTime == entity.BillTime)
                                      .List().Count
                                      > 0;
            }
            if (entity.Kilometrage != null)
            {
                isDuplicate |= session.QueryOver<FuelBill>()
                                      .Where(x => x.Kilometrage == entity.Kilometrage)
                                      .List().Count
                                      > 0;
            }
            return isDuplicate;
        }
        
        public void Update(FuelBill entity)
        {
            using (ISession session = NHibernateSessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        public void Remove(FuelBill entity)
        {
            throw new NotImplementedException();
        }
    }
}
