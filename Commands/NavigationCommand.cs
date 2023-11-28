using Drugstore_Application.Model.Base;
using Drugstore_Application.Stores;
using Drugstore_Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.Commands
{
    public class NavigationCommand<TViewModel> : CommandBase
        where TViewModel : PropertyChange
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _changeVM;

        public NavigationCommand(NavigationStore navigationStore, Func<TViewModel> changeVM)
        {
            _navigationStore = navigationStore;
            _changeVM = changeVM;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _changeVM();
        }
    }
}
