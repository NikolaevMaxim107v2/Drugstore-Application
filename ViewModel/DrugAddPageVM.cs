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
    public class DrugAddPageVM : PropertyChange
    {
        private string _addName;
        private string _addSymptoms;
        private int _addCount;
        private double _addPrice;
        private double _addBuyprice;

        public int CurDrugId;
        public ICommand DrugAdd { get; }
        public ICommand BackToMain { get; }
        public ObservableCollection<Drug> DrugsList { get; set; }

        public string AddName { get => _addName; set { _addName = value; OnPropertyChanged(nameof(AddName)); } }
        public string AddSymptoms { get => _addSymptoms; set { _addSymptoms = value; OnPropertyChanged(nameof(AddSymptoms)); } }
        public int AddCount { get => _addCount; set { _addCount = value; OnPropertyChanged(nameof(AddCount)); } }
        public double AddPrice { get => _addPrice; set { _addPrice = value; OnPropertyChanged(nameof(AddPrice)); } }
        public double AddBuyprice { get => _addBuyprice; set { _addBuyprice = value; OnPropertyChanged(nameof(AddBuyprice)); } }
        public DrugAddPageVM(NavigationStore navigationStore, DrugsListStore drugsList, TransactionsListStore transactionsList, BalanceStore balanceStore) 
        {
            DrugsList = drugsList.DrugsList;
            CurDrugId = drugsList.CurDrugId;
            DrugAdd = new DrugAddCommand(this, navigationStore);
            BackToMain = new BackToMainCommand(navigationStore, drugsList,transactionsList, balanceStore);
        }
    }
}
