using Drugstore_Application.Model.Base;
using Drugstore_Application.Stores;
using Drugstore_Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugstore_Application.Commands
{
    public class BackToMainCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        public ICommand NavigateToMainPageCommand { get; }

        public BackToMainCommand(NavigationStore navigationStore, DrugsListStore drugsListStore, TransactionsListStore transactionsListStore, BalanceStore balanceStore)
        {
            this.navigationStore = navigationStore;
            NavigateToMainPageCommand = new NavigationCommand<MainPageVM>(navigationStore, () => new MainPageVM(navigationStore, drugsListStore, transactionsListStore, balanceStore));
        }

        public override void Execute(object parameter)
        {
            NavigateToMainPageCommand.Execute(true);
        }
    }
}
