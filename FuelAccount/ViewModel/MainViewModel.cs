using FuelAccount.Util;
using FuelAccountModel.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NHibernate;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FuelAccount.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ViewModelBase> _workspaces;
        private ReadOnlyObservableCollection<ViewModelBase> _workspacesReadOnly;
        private RelayCommand _testConnectionCommand;
        private RelayCommand _newFuelBillCommand;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            _workspaces = new ObservableCollection<ViewModelBase>();
            _workspaces.Add(new AllFuelBillsViewModel());
        }

        public ReadOnlyObservableCollection<ViewModelBase> Workspaces
        {
            get
            {
                if (_workspacesReadOnly == null)
                {
                    _workspacesReadOnly = new ReadOnlyObservableCollection<ViewModelBase>(_workspaces);
                }
                return _workspacesReadOnly;
            }
        }

        public ICommand NewFuelBillCommand
        {
            get
            {
                if (_newFuelBillCommand == null)
                {
                    _newFuelBillCommand = new RelayCommand(() => this.NewFuelBill());
                }
                return _newFuelBillCommand;
            }
        }

        private void NewFuelBill()
        {
            _workspaces.Add(new FuelBillViewModel());
        }

        public ICommand TestConnectionCommand
        {
            get
            {
                if (_testConnectionCommand == null)
                {
                    _testConnectionCommand = new RelayCommand(() => TestConnection());
                }
                return _testConnectionCommand;
            }
        }

        private void TestConnection()
        {
            using (ISession session = NHibernateSessionFactory.OpenSession())
            {
                Fuel fuel = session.Get<Fuel>(1);
                FuelStation station = session.Get<FuelStation>(1);
                FuelBill bill = session.Get<FuelBill>(1);
            }
        }
    }
}