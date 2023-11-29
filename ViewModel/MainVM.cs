using Drugstore_Application.Model;
using Drugstore_Application.Model.Base;
using Drugstore_Application.Stores;
using Drugstore_Application.View;
using Drugstore_Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup.Localizer;

namespace Drugstore_Application.ViewModel
{
    public class MainVM : PropertyChange
    {
        private readonly NavigationStore _navigationStore;
        private readonly DrugsListStore _drugsListStore;
        private readonly TransactionsListStore _transactionsListStore;
        private readonly BalanceStore _balanceStore;

        public PropertyChange CurrentViewModel => _navigationStore.CurrentViewModel;
        public ObservableCollection<Drug> DrugsList => _drugsListStore.DrugsList;
        public ObservableCollection<TransactionDS> TransactionsList => _transactionsListStore.TransactionsList;
        public double Balance => _balanceStore.Balance;

        public MainVM(NavigationStore navigationStore, DrugsListStore drugsListStore, TransactionsListStore transactionsListStore, BalanceStore balanceStore)
        {
            _navigationStore = navigationStore;
            _drugsListStore = drugsListStore;
            _transactionsListStore = transactionsListStore;
            _balanceStore = balanceStore;
            _balanceStore.BalanceChanged += OnBalanceChanged;
            _drugsListStore.DrugsListChanged += OnDrugsListChanged;
            _transactionsListStore.TransactionsListChanged += OnTransactionsListChanged;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnDrugsListChanged()
        {
            OnPropertyChanged(nameof(DrugsList));
        }

        private void OnTransactionsListChanged()
        {
            OnPropertyChanged(nameof(TransactionsList));
        }

        private void OnBalanceChanged()
        {
            OnPropertyChanged(nameof(Balance));
        }
    }
}
