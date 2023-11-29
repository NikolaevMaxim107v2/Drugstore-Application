using Drugstore_Application.Commands;
using Drugstore_Application.Model.Base;
using Drugstore_Application.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Drugstore_Application.ViewModel
{
    public class LogInPageVM : PropertyChange
    {
        private string login;
        private string password;
        public ICommand LoginCommand { get; }
        public string Password { get => password; set { password = value; OnPropertyChanged(nameof(Password)); } }
        public string Login { get => login; set { login = value; OnPropertyChanged(nameof(Login)); } }



        public LogInPageVM(NavigationStore navigationStore, DrugsListStore drugsListStore, TransactionsListStore transactionsListStore, BalanceStore balanceStore) 
        {
            login = "Логин";
            password = "Пароль";
            LoginCommand = new LoginCommand(this,navigationStore,drugsListStore, transactionsListStore, balanceStore);
        }
    }
}
