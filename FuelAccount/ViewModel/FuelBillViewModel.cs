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
    public class FuelBillViewModel : WorkspaceViewModel
    {
        bool _isNewFuelBill;
        FuelBill _fuelBill;
        ObservableCollection<FuelViewModel> _fuels;
        ReadOnlyObservableCollection<FuelViewModel> _fuelsReadOnly;
        ObservableCollection<FuelStationViewModel> _fuelStations;
        ReadOnlyObservableCollection<FuelStationViewModel> _fuelStationsReadOnly;

        FuelViewModel _fuel;
        FuelStationViewModel _fuelStation;
        DateTime? _billDate;
        public TimeSpan? _billTime;
        public float? _fuelPrice;
        public float? _litres;
        public float? _discount;
        public double? _payment;
        public float? _kilometrage;

        RelayCommand _saveCommand;

        IFuelRepository _fuelRepository;
        IFuelBillRepository _fuelBillRepository;
        IFuelStationRepository _fuelStationRepository;

        public FuelBillViewModel()
        {
            _isNewFuelBill = true;
            _fuelBill = new FuelBill();
        }

        public FuelBillViewModel(FuelBill bill)
        {
            _isNewFuelBill = false;
            _fuelBill = bill;
            this.Fuel = new FuelViewModel(bill.Fuel);
            if (bill.FuelStation != null)
            {
                this.FuelStation = new FuelStationViewModel(bill.FuelStation);
            }
            else
            {
                this.FuelStation = null;
            }
            this.BillDate = bill.BillDate;
            if (bill.BillTime != null)
            {
                this.BillTime = bill.BillTime;
            }
            else
            {
                this.BillTime = null;
            }
            this.FuelPrice = bill.FuelPrice;
            this.Litres = bill.Litres;
            this.Discount = bill.Discount;
            this.Payment = bill.Payment;
            this.Kilometrage = bill.Kilometrage;
        }

        private IFuelRepository FuelRepository
        {
            get
            {
                if (_fuelRepository == null)
                {
                    _fuelRepository = new FuelRepository();
                }
                return _fuelRepository;
            }
        }

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

        private IFuelStationRepository FuelStationRepository
        {
            get
            {
                if (_fuelStationRepository == null)
                {
                    _fuelStationRepository = new FuelStationRepository();
                }
                return _fuelStationRepository;
            }
        }

        public override string DisplayName
        {
            get
            {
                if (_isNewFuelBill)
                {
                    return "New Fuel Bill";
                }
                else
                {
                    return ((DateTime)this.BillDate).ToShortDateString();
                }
            }
        }
        
        public ReadOnlyObservableCollection<FuelViewModel> Fuels
        {
            get
            {
                if (_fuelsReadOnly == null)
                {
                    _fuels = new ObservableCollection<FuelViewModel>();
                    foreach (var fuel in this.FuelRepository.GetAll())
                    {
                        _fuels.Add(new FuelViewModel(fuel));
                    }
                    _fuelsReadOnly = new ReadOnlyObservableCollection<FuelViewModel>(_fuels);
                }
                return _fuelsReadOnly;
            }
        }

        public ReadOnlyObservableCollection<FuelStationViewModel> FuelStations
        {
            get
            {
                if (_fuelStationsReadOnly == null)
                {
                    _fuelStations = new ObservableCollection<FuelStationViewModel>();
                    foreach (var fuelStation in this.FuelStationRepository.GetAll())
                    {
                        _fuelStations.Add(new FuelStationViewModel(fuelStation));
                    }
                    _fuelStationsReadOnly = new ReadOnlyObservableCollection<FuelStationViewModel>(_fuelStations);
                }
                return _fuelStationsReadOnly;
            }
        }

        public FuelViewModel Fuel
        {
            get
            {
                return _fuel;
            }
            set
            {
                if (_fuel == value)
                {
                    return;
                }
                _fuel = value;
                RaisePropertyChanged(() => Fuel);
                RaiseSaveCommandCanExecuteChanged();
            }
        }

        public FuelStationViewModel FuelStation
        {
            get
            {
                return _fuelStation;
            }
            set
            {
                if (_fuelStation == value)
                {
                    return;
                }
                _fuelStation = value;
                RaisePropertyChanged(() => FuelStation);
                RaiseSaveCommandCanExecuteChanged();
            }
        }

        public DateTime? BillDate
        {
            get
            {
                return _billDate;
            }
            set
            {
                if (_billDate == value)
                {
                    return;
                }
                _billDate = value;
                RaisePropertyChanged(() => BillDate);
                RaiseSaveCommandCanExecuteChanged();
            }
        }

        public TimeSpan? BillTime
        {
            get
            {
                return _billTime;
            }
            set
            {
                if (_billTime == value)
                {
                    return;
                }
                _billTime = value;
                RaisePropertyChanged(() => BillTime);
                RaiseSaveCommandCanExecuteChanged();
            }
        }

        public float? FuelPrice
        {
            get
            {
                return _fuelPrice;
            }
            set
            {
                if (_fuelPrice == value)
                {
                    return;
                }
                _fuelPrice = value;
                RaisePropertyChanged(() => FuelPrice);
                RaiseSaveCommandCanExecuteChanged();
            }
        }

        public float? Litres
        {
            get
            {
                return _litres;
            }
            set
            {
                if (_litres == value)
                {
                    return;
                }
                _litres = value;
                RaisePropertyChanged(() => Litres);
                RaiseSaveCommandCanExecuteChanged();
            }
        }

        public float? Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                if (_discount == value)
                {
                    return;
                }
                _discount = value;
                RaisePropertyChanged(() => Discount);
                RaiseSaveCommandCanExecuteChanged();
            }
        }

        public double? Payment
        {
            get
            {
                return _payment;
            }
            set
            {
                if (_payment == value)
                {
                    return;
                }
                _payment = value;
                RaisePropertyChanged(() => Payment);
                RaiseSaveCommandCanExecuteChanged();
            }
        }

        public float? Kilometrage
        {
            get
            {
                return _kilometrage;
            }
            set
            {
                if (_kilometrage == value)
                {
                    return;
                }
                _kilometrage = value;
                RaisePropertyChanged(() => Kilometrage);
                RaiseSaveCommandCanExecuteChanged();
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(() => this.Save(), () => this.CanSave);
                }
                return _saveCommand;
            }
        }

        private void Save()
        {
            if (this.CanSave)
            {
                FuelBill bill = _fuelBill;
                bill.BillDate = ((DateTime)this.BillDate).Date;
                if (this.BillTime != null)
                {
                    bill.BillTime = (TimeSpan)this.BillTime;
                }
                else
                {
                    bill.BillTime = null;
                }
                bill.Fuel = this.FuelRepository.Get(this.Fuel.FuelId);
                if (this.FuelStation != null)
                {
                    bill.FuelStation = this.FuelStationRepository.Get(this.FuelStation.FuelStationId);
                }
                else
                {
                    bill.FuelStation = null;
                }
                bill.FuelPrice = (float)this.FuelPrice;
                bill.Litres = (float)this.Litres;
                bill.Discount = this.Discount;
                bill.Payment = this.Payment;
                bill.Kilometrage = this.Kilometrage;
                if (_isNewFuelBill)
                {
                    this.FuelBillRepository.Add(bill);
                    _isNewFuelBill = false;
                }
                else
                {
                    this.FuelBillRepository.Update(bill);
                }

                RaisePropertyChanged(() => DisplayName);
            }
        }

        private bool CanSave
        {
            get
            {
                if (this.BillDate == null)
                {
                    return false;
                }
                if (this.Fuel == null)
                {
                    return false;
                }
                if (this.FuelPrice == null)
                {
                    return false;
                }
                if (this.Litres == null)
                {
                    return false;
                }
                return true;
            }
        }
        
        private void RaiseSaveCommandCanExecuteChanged()
        {
            if (_saveCommand != null)
            {
                _saveCommand.RaiseCanExecuteChanged();
            }
        }
    }
}
