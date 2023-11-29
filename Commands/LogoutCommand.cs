using Drugstore_Application.Model.Base;
using Drugstore_Application.Stores;
using Drugstore_Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Drugstore_Application.Commands
{
    public class LogoutCommand : CommandBase
    {
        private MainPageVM _mainPageVM;
        private NavigationStore _navigationStore;
        public ICommand NavigateToStartPageCommand { get; }

        public LogoutCommand(MainPageVM mainPageVM, NavigationStore navigationStore, DrugsListStore drugsList, TransactionsListStore transactionsList, BalanceStore balanceStore)
        {
            _mainPageVM = mainPageVM;
            _navigationStore = navigationStore;
            NavigateToStartPageCommand = new NavigationCommand<StartPageVM>(navigationStore, () => new StartPageVM(navigationStore, drugsList, transactionsList, balanceStore));
        }

        public override void Execute(object parameter)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes)
            {
                NavigateToStartPageCommand.Execute(true);
            }
            else
            {
                return;
            }
        }
    }
}
