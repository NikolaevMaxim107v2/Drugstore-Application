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
    public class DrugSellPageVM : PropertyChange
    {
        private string textSearchDrug;
        private int sellCount;
        private Drug selectedDrug;
        public ObservableCollection<Drug> DrugsList { get; set; }
        public ObservableCollection<TransactionDS> TransactionsList { get; set; }

        public int SellCount { get => sellCount; set { sellCount = value; OnPropertyChanged(nameof(SellCount)); } }

        private double balance;
        public int CurTransactionId;
        public int CurDrugId;
        public ICommand DrugSell { get; }
        public ICommand BackToMain { get; }

        public double Balance { get { return Math.Round(balance, 2); } set { balance = Convert.ToDouble(value); OnPropertyChanged(nameof(Balance)); } }

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
        public DrugSellPageVM(NavigationStore navigationStore, DrugsListStore drugsList, TransactionsListStore transactionsList, BalanceStore balanceStore)
        {
            DrugsList = drugsList.DrugsList;
            CurDrugId = drugsList.CurDrugId;
            Balance = balanceStore.Balance;
            TransactionsList = transactionsList.TransactionsList;
            CurTransactionId = transactionsList.CurTransactionId;
            DrugSell = new DrugSellCommand(this, navigationStore);
            BackToMain = new BackToMainCommand(navigationStore, drugsList, transactionsList, balanceStore);
        }
    }
}
