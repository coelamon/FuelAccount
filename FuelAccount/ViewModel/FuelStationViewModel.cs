using FuelAccountModel.Domain;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelAccount.ViewModel
{
    public class FuelStationViewModel : ViewModelBase
    {
        public FuelStationViewModel(FuelStation fuelStation)
        {
            if (fuelStation == null)
            {
                throw new ArgumentException();
            }
            this.FuelStationId = fuelStation.FuelStationId;
            this.Name = fuelStation.Name;
            this.Address = fuelStation.Address;
        }

        public int FuelStationId
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public string Address
        {
            get;
            private set;
        }
    }
}
