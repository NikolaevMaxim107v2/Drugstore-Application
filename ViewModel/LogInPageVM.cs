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
        private RelayCommand logIn;
        public ICommand NavigateToMainPageCommand { get; }
        public string Password { get => password; set { password = value; OnPropertyChanged(nameof(Password)); } }
        public string Login { get => login; set { login = value; OnPropertyChanged(nameof(Login)); } }


        public RelayCommand LogIn
        {
            get
            {
                return logIn ?? (logIn = new RelayCommand(obj =>
                {
                    if ((login == "admin") && (password == "admin"))
                    {
                        MessageBox.Show($"Здравствуйте, {login}! Для перехода далее нажмите 'ОК'", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigateToMainPageCommand.Execute(true);
                    }
                    else
                    {
                        ErrorBox.LogInError();
                    }
                }));
            }
        }

        public LogInPageVM(NavigationStore navigationStore) 
        {
            login = "Логин";
            password = "Пароль";
            NavigateToMainPageCommand = new NavigationCommand<MainPageVM>(navigationStore, () => new MainPageVM(navigationStore));
        }
    }
}
