using FuelAccountModel.Domain;
using NHibernate;
using System;
using System.Collections.Generic;

namespace FuelAccount.Repository
{
    public class FuelRepository : NHibernateRepository<Fuel, int>, IFuelRepository
    {
        public void Add(Fuel entity)
        {
            throw new NotImplementedException();
        }
        
        public void Update(Fuel entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Fuel entity)
        {
            throw new NotImplementedException();
        }
    }
}
