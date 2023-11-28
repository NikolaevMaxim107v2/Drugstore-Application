using Drugstore_Application.Model;
using Drugstore_Application.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.ViewModel
{
    public class MainPageVM : PropertyChange
    {
        private string textSearchDrug;
        private string addName;
        private string addSymptoms;
        private int addCount;
        private double addPrice;
        private double addBuyprice;
        private int buySellEliminateCount;
        private Drug selectedDrug;
        private RelayCommand removeDrug;
        private RelayCommand addDrug;
        private RelayCommand buyDrug;
        private RelayCommand eliminateDrug;
        private RelayCommand sellDrug;
    }
}
