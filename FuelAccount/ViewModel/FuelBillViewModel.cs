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
    public class FuelBillViewModel : ViewModelBase
    {
        int? _id;
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

        public FuelBillViewModel()
        {

        }

        public FuelBillViewModel(FuelBill bill)
        {
            _id = bill.FuelBillId;
            this.Fuel = new FuelViewModel(bill.Fuel);
            this.FuelStation = new FuelStationViewModel(bill.FuelStation);
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

        public string DisplayName
        {
            get
            {
                if (_id == null)
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
                    using (ISession session = NHibernateSessionFactory.OpenSession())
                    {
                        IList<Fuel> fuels = session.QueryOver<Fuel>().List();
                        foreach (var fuel in fuels)
                        {
                            _fuels.Add(new FuelViewModel(fuel));
                        }
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
                    using (ISession session = NHibernateSessionFactory.OpenSession())
                    {
                        IList<FuelStation> fuelStations = session.QueryOver<FuelStation>().List();
                        foreach (var fuelStation in fuelStations)
                        {
                            _fuelStations.Add(new FuelStationViewModel(fuelStation));
                        }
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
                SaveCommandRaiseCanExecuteChanged();
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
                SaveCommandRaiseCanExecuteChanged();
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
                SaveCommandRaiseCanExecuteChanged();
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
                SaveCommandRaiseCanExecuteChanged();
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
                SaveCommandRaiseCanExecuteChanged();
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
                SaveCommandRaiseCanExecuteChanged();
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
                SaveCommandRaiseCanExecuteChanged();
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
                SaveCommandRaiseCanExecuteChanged();
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
                SaveCommandRaiseCanExecuteChanged();
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
                using (ISession session = NHibernateSessionFactory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        FuelBill bill = null;
                        if (_id == null)
                        {
                            bill = new FuelBill();
                        }
                        else
                        {
                            bill = session.Get<FuelBill>(_id);
                        }
                        bill.BillDate = ((DateTime)this.BillDate).Date;
                        if (this.BillTime != null)
                        {
                            bill.BillTime = (TimeSpan)this.BillTime;
                        }
                        else
                        {
                            bill.BillTime = null;
                        }
                        bill.Fuel = session.Get<Fuel>(this.Fuel.FuelId);
                        bill.FuelStation = session.Get<FuelStation>(this.FuelStation.FuelStationId);
                        bill.FuelPrice = (float)this.FuelPrice;
                        bill.Litres = (float)this.Litres;
                        bill.Discount = this.Discount;
                        bill.Payment = this.Payment;
                        bill.Kilometrage = this.Kilometrage;
                        if (_id == null)
                        {
                            session.Save(bill);
                            _id = bill.FuelBillId;
                        }
                        else
                        {
                            session.Update(bill);
                        }
                        transaction.Commit();
                    }
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
                if (this.FuelStation == null)
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

        private void SaveCommandRaiseCanExecuteChanged()
        {
            if (_saveCommand != null)
            {
                _saveCommand.RaiseCanExecuteChanged();
            }
        }
    }
}
