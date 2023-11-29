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
    public class LoginCommand : CommandBase
    {
        private readonly LogInPageVM _viewModel;
        private readonly NavigationStore _navigationStore;
        public ICommand NavigateToMainPageCommand { get; }
        public LoginCommand(LogInPageVM viewModel, NavigationStore navigationStore, DrugsListStore drugsListStore, TransactionsListStore transactionsListStore, BalanceStore balanceStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
            NavigateToMainPageCommand = new NavigationCommand<MainPageVM>(navigationStore, () => new MainPageVM(navigationStore, drugsListStore, transactionsListStore, balanceStore));
        }

        public override void Execute(object parameter)
        {
            if ((_viewModel.Login == "admin") && (_viewModel.Password == "admin"))
            {
                MessageBox.Show($"Здравствуйте, {_viewModel.Login}! Для перехода далее нажмите 'ОК'", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigateToMainPageCommand.Execute(true);
            }
            else
            {
                ErrorBox.LogInError();
            }
        }
    }
}
