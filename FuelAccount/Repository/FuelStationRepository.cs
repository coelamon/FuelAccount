using FuelAccountModel.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelAccount.Repository
{
    public class FuelStationRepository : NHibernateRepository<FuelStation, int>, IFuelStationRepository
    {
        public void Add(FuelStation entity)
        {
            throw new NotImplementedException();
        }
        
        public void Update(FuelStation entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(FuelStation entity)
        {
            throw new NotImplementedException();
        }
    }
}
