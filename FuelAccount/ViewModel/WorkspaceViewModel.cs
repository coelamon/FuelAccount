using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuelAccount.ViewModel
{
    public class WorkspaceViewModel : ViewModelBase
    {
        RelayCommand _closeCommand;

        public event Action<WorkspaceViewModel> CloseRequested;

        public virtual string DisplayName
        {
            get;
        }

        protected void OnCloseRequested()
        {
            this.CloseRequested?.Invoke(this);
        }

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(() => this.OnCloseRequested());
                }
                return _closeCommand;
            }
        }
    }
}
