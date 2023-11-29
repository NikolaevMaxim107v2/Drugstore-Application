using Drugstore_Application.Commands;
using Drugstore_Application.Model.Base;
using Drugstore_Application.Model;
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
    public class DrugChangePageVM : PropertyChange
    {
        private string textSearchDrug;
        private int sellCount;
        private Drug selectedDrug;
        public ObservableCollection<Drug> DrugsList { get; set; }
        public ObservableCollection<TransactionDS> TransactionsList { get; set; }

        public int SellCount { get => sellCount; set { sellCount = value; OnPropertyChanged(nameof(SellCount)); } }

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
        public DrugChangePageVM(NavigationStore navigationStore, DrugsListStore drugsList, TransactionsListStore transactionsList, BalanceStore balanceStore)
        {
            DrugsList = drugsList.DrugsList;
            TransactionsList = transactionsList.TransactionsList;
            BackToMain = new BackToMainCommand(navigationStore, drugsList, transactionsList, balanceStore);
        }
    }
}
