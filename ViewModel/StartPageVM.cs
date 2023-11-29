using Drugstore_Application.Commands;
using Drugstore_Application.Model.Base;
using Drugstore_Application.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugstore_Application.ViewModel
{
    public class StartPageVM : PropertyChange
    {
        public ICommand NavigateToLoginPageCommand { get; }

        public StartPageVM(NavigationStore navigationStore, DrugsListStore drugsListStore, TransactionsListStore transactionsListStore, BalanceStore balanceStore)
        {
            NavigateToLoginPageCommand = new NavigationCommand<LogInPageVM>(navigationStore, () => new LogInPageVM(navigationStore, drugsListStore, transactionsListStore, balanceStore));
        }

    }
}
