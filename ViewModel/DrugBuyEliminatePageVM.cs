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
    public class DrugBuyEliminatePageVM : PropertyChange
    {
        private string textSearchDrug;
        private double balance;
        private int buyCount;
        private int eliminateCount;
        private Drug selectedDrug;
        public ObservableCollection<Drug> DrugsList { get; set; }
        public ObservableCollection<TransactionDS> TransactionsList { get; set; }

        public int BuyCount { get => buyCount; set { buyCount = value; OnPropertyChanged(nameof(BuyCount)); } }
        public int EliminateCount { get => eliminateCount; set { eliminateCount = value; OnPropertyChanged(nameof(EliminateCount)); } }
        public double Balance { get => balance; set { balance = value; OnPropertyChanged(nameof(Balance)); } }

        public int CurTransactionId;
        public ICommand DrugBuy { get; }
        public ICommand DrugEliminate { get; }
        public ICommand BackToMain { get; }

        public Drug SelectedDrug
        {
            get { return selectedDrug; }
            set { selectedDrug = value; OnPropertyChanged(nameof(SelectedDrug)); }
        }

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
        public DrugBuyEliminatePageVM(NavigationStore navigationStore, DrugsListStore drugsList, TransactionsListStore transactionsList, BalanceStore balanceStore)
        {
            DrugsList = drugsList.DrugsList;;
            Balance = balanceStore.Balance;
            TransactionsList = transactionsList.TransactionsList;
            CurTransactionId = transactionsList.CurTransactionId;
            DrugBuy = new DrugBuyCommand(this, navigationStore);
            DrugEliminate = new DrugEliminateCommand(this, navigationStore);
            BackToMain = new BackToMainCommand(navigationStore, drugsList, transactionsList, balanceStore);
        }
    }
}
