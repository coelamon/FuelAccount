using FuelAccount.Util;
using FuelAccountModel.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuelAccount.ViewModel
{
    class AllFuelBillsViewModel : ViewModelBase
    {
        ObservableCollection<FuelBillViewModel> _fuelBills;
        ReadOnlyObservableCollection<FuelBillViewModel> _fuelBillsReadOnly;
        RelayCommand _reloadCommand;

        public ReadOnlyObservableCollection<FuelBillViewModel> AllFuelBills
        {
            get
            {
                if (_fuelBillsReadOnly == null)
                {
                    ReloadAllFuelBills();
                    _fuelBillsReadOnly = new ReadOnlyObservableCollection<FuelBillViewModel>(_fuelBills);
                }
                return _fuelBillsReadOnly;
            }
        }

        public string DisplayName
        {
            get
            {
                return "All";
            }
        }

        private void ReloadAllFuelBills()
        {
            if (_fuelBills == null)
            {
                _fuelBills = new ObservableCollection<FuelBillViewModel>();
            }
            _fuelBills.Clear();
            using (ISession session = NHibernateSessionFactory.OpenSession())
            {
                foreach (var bill in session.QueryOver<FuelBill>().List())
                {
                    _fuelBills.Add(new FuelBillViewModel(bill));
                }
            }
        }

        public ICommand ReloadCommand
        {
            get
            {
                if (_reloadCommand == null)
                {
                    _reloadCommand = new RelayCommand(() => ReloadAllFuelBills());
                }
                return _reloadCommand;
            }
        }
    }
}
