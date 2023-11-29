using Drugstore_Application.Commands;
using Drugstore_Application.Model;
using Drugstore_Application.Model.Base;
using Drugstore_Application.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drugstore_Application.ViewModel
{
    public class MainPageVM : PropertyChange
    {
        private string textSearchDrug;
        private int buySellEliminateCount;
        private Drug selectedDrug;
        private double balance;

        public ICommand DrugBuy { get; }
        public ICommand DrugRemove { get; }
        public ICommand DrugEliminate { get; }
        public ICommand NavigateToDrugAddPageCommand { get; }
        public ICommand NavigateToDrugSellPageCommand { get; }
        public ICommand NavigateToDrugChangePageCommand { get; }
        public ICommand NavigateToDrugBuyEliminatePageCommand { get; }
        public ICommand LogoutCommand { get; }

        public ObservableCollection<Drug> DrugsList { get; set; }
        public ObservableCollection<TransactionDS> TransactionsList { get; set; }
        
        public int CurTransactionId;
        public int CurDrugId;

        public Drug SelectedDrug
        {
            get { return selectedDrug; }
            set { selectedDrug = value; OnPropertyChanged(nameof(SelectedDrug)); }
        }

        public double Balance { get { return Math.Round(balance, 2); } set { balance = Convert.ToDouble(value); OnPropertyChanged(nameof(Balance)); } }
        public int BuySellEliminateCount { get => buySellEliminateCount; set { buySellEliminateCount = value; OnPropertyChanged(nameof(BuySellEliminateCount)); } }

        public string TextSearchDrug
        {
            get { return textSearchDrug; }
            set
            {
                textSearchDrug = value;
                OnPropertyChanged(nameof(FoundDrugs));
                OnPropertyChanged(nameof(TextSearchDrug));
            }
        }

        public ObservableCollection<Drug> FoundDrugs //Поиск медикаментов
        {
            get
            {
                if (textSearchDrug != null)
                {
                    return new ObservableCollection<Drug>
                        (DrugsList.Where(drug => ((Convert.ToString(drug.Id).ToLower() + drug.Name.ToLower() + drug.Symptoms.ToLower()) + Convert.ToString(drug.Count).ToLower() + Convert.ToString(drug.Price).ToLower()).Contains(TextSearchDrug.ToLower())));
                }
                else
                {
                    return DrugsList;
                }
            }
        }


        //Команды


        public MainPageVM(NavigationStore navigationStore, DrugsListStore drugsList, TransactionsListStore transactionsList, BalanceStore balanceStore)
        {
            DrugsList = drugsList.DrugsList;
            CurDrugId = drugsList.CurDrugId;
            TransactionsList = transactionsList.TransactionsList;
            CurTransactionId = transactionsList.CurTransactionId;
            Balance = balanceStore.Balance;
            NavigateToDrugAddPageCommand = new NavigationCommand<DrugAddPageVM>(navigationStore, () => new DrugAddPageVM(navigationStore, drugsList, transactionsList, balanceStore));
            NavigateToDrugSellPageCommand = new NavigationCommand<DrugSellPageVM>(navigationStore, () => new DrugSellPageVM(navigationStore, drugsList, transactionsList, balanceStore));
            NavigateToDrugChangePageCommand = new NavigationCommand<DrugChangePageVM>(navigationStore, () => new DrugChangePageVM(navigationStore, drugsList, transactionsList, balanceStore));
            NavigateToDrugBuyEliminatePageCommand = new NavigationCommand<DrugBuyEliminatePageVM>(navigationStore, () => new DrugBuyEliminatePageVM(navigationStore, drugsList, transactionsList, balanceStore));
            LogoutCommand = new LogoutCommand(this, navigationStore, drugsList, transactionsList, balanceStore);
            DrugRemove = new DrugRemoveCommand(this, navigationStore);
        }
    }
}
