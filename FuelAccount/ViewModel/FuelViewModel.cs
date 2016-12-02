using FuelAccountModel.Domain;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelAccount.ViewModel
{
    public class FuelViewModel : ViewModelBase
    {
        public FuelViewModel(Fuel fuel)
        {
            this.FuelId = fuel.FuelId;
            this.Name = fuel.Name;
        }

        public int FuelId
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }
    }
}
