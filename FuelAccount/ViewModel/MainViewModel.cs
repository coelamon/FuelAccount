using FuelAccount.Util;
using FuelAccountModel.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NHibernate;
using System;
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
        private ObservableCollection<ViewModelBase> _workspaces = new ObservableCollection<ViewModelBase>();
        private ReadOnlyObservableCollection<ViewModelBase> _workspacesReadOnly;
        private RelayCommand _newFuelBillCommand;
        private RelayCommand _showAllFuelBillsCommand;

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

        public ICommand ShowAllFuelBillsCommand
        {
            get
            {
                if (_showAllFuelBillsCommand == null)
                {
                    _showAllFuelBillsCommand = new RelayCommand(() => this.ShowAllFuelBills());
                }
                return _showAllFuelBillsCommand;
            }
        }

        private void ShowAllFuelBills()
        {
            foreach (var workspace in _workspaces)
            {
                if (workspace is AllFuelBillsViewModel)
                {
                    return;
                }
            }
            AllFuelBillsViewModel allFuelBills = new AllFuelBillsViewModel();
            allFuelBills.CloseRequested += new Action<WorkspaceViewModel>(OnWorkspaceCloseRequested);
            _workspaces.Insert(0, allFuelBills);
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
            FuelBillViewModel newFuelBill = new FuelBillViewModel();
            newFuelBill.CloseRequested += new Action<WorkspaceViewModel>(OnWorkspaceCloseRequested);
            _workspaces.Add(newFuelBill);
        }

        private void OnWorkspaceCloseRequested(WorkspaceViewModel workspace)
        {
            _workspaces.Remove(workspace);
        }
    }
}