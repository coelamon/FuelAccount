using FuelAccount.Repository;
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
    class AllFuelBillsViewModel : WorkspaceViewModel
    {
        ObservableCollection<FuelBillViewModel> _fuelBills;
        ReadOnlyObservableCollection<FuelBillViewModel> _fuelBillsReadOnly;
        RelayCommand _reloadCommand;

        IFuelBillRepository _fuelBillRepository;

        private IFuelBillRepository FuelBillRepository
        {
            get
            {
                if (_fuelBillRepository == null)
                {
                    _fuelBillRepository = new FuelBillRepository();
                }
                return _fuelBillRepository;
            }
        }

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

        public override string DisplayName
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
            foreach (var bill in this.FuelBillRepository.GetAll())
            {
                _fuelBills.Add(new FuelBillViewModel(bill));
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
