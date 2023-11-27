using Drugstore_Application.Model;
using Drugstore_Application.Model.Base;
using Drugstore_Application.Services;
using Drugstore_Application.View;
using Drugstore_Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup.Localizer;

namespace Drugstore_Application.ViewModel
{
    public class MainVM : PropertyChange
    {
        //Приватные переменные
        private string textSearchDrug;
        private string login;
        private string password;
        private string addName;
        private string addSymptoms;
        private int addCount;
        private double addPrice;
        private double addBuyprice;
        private int buyEliminateCount;
        //private string newName;
        //private string newSymptoms;
        //private int newCount;
        //private double newPrice;
        //private double newBuyprice;
        private Drug selectedDrug;
        private IWindowService _windowService;
        //private IWindowService _windowService1;
        //private IWindowService _windowService2;
        private RelayCommand removeDrug;
        private RelayCommand addDrug;
        private RelayCommand buyDrug;
        private RelayCommand eliminateDrug;
        private RelayCommand logIn;
        private RelayCommand addWindow;

        //Публичные переменные
        public ObservableCollection<Drug> DrugsList { get; set; }
        public ObservableCollection<Transaction> TransactionsList { get; set; }
        public List<string> TransactionTypes;
        public ICommand OpenWindowCommand { get; set; }
        //public ICommand CloseWindowCommand1 { get; set; }
        //public ICommand OpenWindowCommand1 { get; set; }
        //public ICommand CloseWindowCommand2 { get; set; }
        //public ICommand OpenWindowCommand2 { get; set; }

        public double balance = 50150;
        public int CurDrugId = 0;
        public int CurTransactionId = 0;

        public Drug SelectedDrug
        {
            get { return selectedDrug; }
            set { selectedDrug = value; OnPropertyChanged(nameof(SelectedDrug)); }
        }

        private void OnOpenWindow()
        {
            _windowService.OpenWindow();
        }

        //private void OnOpenWindow1()
        //{
        //    _windowService1.OpenWindow();
        //}

        //private void OnCloseWindow1()
        //{
        //    _windowService1.CloseWindow();
        //}

        //private void OnOpenWindow2()
        //{
        //    _windowService2.OpenWindow();
        //}

        //private void OnCloseWindow2()
        //{
        //    _windowService2.CloseWindow();
        //}

        public double Balance { get { return Math.Round(balance,2); } set { balance = Convert.ToDouble(value); OnPropertyChanged(nameof(Balance)); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(nameof(Password)); } }
        public string Login { get => login; set { login = value; OnPropertyChanged(nameof(Login)); } }
        //public string NewName { get => newName; set { newName = value; OnPropertyChanged(nameof(NewName)); } }
        //public string NewSymptoms { get => newSymptoms; set { newSymptoms = value; OnPropertyChanged(nameof(NewSymptoms)); } }
        //public int NewCount { get => newCount; set { newCount = value; OnPropertyChanged(nameof(NewCount)); } }
        //public double NewPrice { get => newPrice; set { newPrice = value; OnPropertyChanged(nameof(NewPrice)); } }
        //public double NewBuyprice { get => newBuyprice; set { newBuyprice = value; OnPropertyChanged(nameof(NewBuyprice)); } }
        public string AddName { get => addName; set { addName = value; OnPropertyChanged(nameof(AddName)); } }
        public string AddSymptoms { get => addSymptoms; set { addSymptoms = value; OnPropertyChanged(nameof(AddSymptoms)); } }
        public int AddCount { get => addCount; set { addCount = value; OnPropertyChanged(nameof(AddCount)); } }
        public double AddPrice { get => addPrice; set { addPrice = value; OnPropertyChanged(nameof(AddPrice)); } }
        public double AddBuyprice { get => addBuyprice; set { addBuyprice = value; OnPropertyChanged(nameof(AddBuyprice)); } }
        public int BuyEliminateCount { get => buyEliminateCount;set { buyEliminateCount = value; OnPropertyChanged(nameof(BuyEliminateCount)); } }

        public string TextSearchDrug
        {
            get {  return textSearchDrug; }
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
        public RelayCommand RemoveDrug
        {
            get
            {
                return removeDrug ?? (removeDrug = new RelayCommand(obj =>
                {

                    if (selectedDrug != null)
                    {
                        if (selectedDrug.Count>0)
                        {
                            CurTransactionId++;
                            TransactionsList.Add(new(CurTransactionId, selectedDrug.Name, selectedDrug.Count,Math.Round(-(selectedDrug.Buyprice*selectedDrug.Count),2), "Списание"));
                        }
                        DrugsList.Remove(selectedDrug);
                        TextSearchDrug = null;
                    }
                    else
                        ErrorBox.DrugSelectError();
                }));
            }
        }

        public RelayCommand LogIn
        {
            get
            {
                return logIn ?? (logIn = new RelayCommand(obj =>
                {
                    if ((login == "admin") && (password == "admin"))
                    {
                        OpenWindowCommand = new RelayCommand(obj => { OnOpenWindow(); });
                        OpenWindowCommand.Execute(true);
                    } 
                    else
                    {
                        ErrorBox.LogInError();
                    }

                }));
            }
        }

        //public RelayCommand OpenAddWindow
        //{
        //    get
        //    {
        //        return addWindow ?? (addWindow = new RelayCommand(obj =>
        //        {
        //            OpenWindowCommand1 = new RelayCommand(obj => { OnOpenWindow1(); });
        //            OpenWindowCommand1.Execute(true);
        //        }));
        //    }
        //}

        public RelayCommand AddNewDrug
        {
            get
            {
                return addDrug ?? (addDrug = new RelayCommand(obj =>
                {
                    if (addName != null)
                    {
                        if (addCount < 0 || addPrice < 0 || addBuyprice < 0)
                            ErrorBox.CountOrPriceError();
                        else
                        {
                            CurDrugId++;
                            DrugsList.Add(new(CurDrugId, addName, addSymptoms, addCount, addPrice, addBuyprice));
                            AddName = null;
                            AddSymptoms = null;
                            AddCount = 0;
                            AddPrice = 0;
                            TextSearchDrug = null;
                        }
                    }
                    else
                        ErrorBox.NameError();

                    //CloseAddWindow.Execute(true);
                }));
            }
        }

        //public RelayCommand CloseAddWindow
        //{
        //    get
        //    {
        //        return addWindow ?? (addWindow = new RelayCommand(obj =>
        //        {
        //            CloseWindowCommand1 = new RelayCommand(obj => { OnCloseWindow1(); });
        //            CloseWindowCommand1.Execute(true);
        //        }));
        //    }
        //}

        public RelayCommand BuyDrug
        {
            get
            {
                return buyDrug ?? (buyDrug = new RelayCommand(obj =>
                {
                    if (selectedDrug != null)
                    {
                        if (buyEliminateCount <= 0)
                            ErrorBox.BuyDrugCountError();
                        else
                        {
                            if ((balance - buyEliminateCount * selectedDrug.Buyprice) >= 0)
                            {
                                selectedDrug.Count = selectedDrug.Count + buyEliminateCount;
                                Balance = balance - (buyEliminateCount * selectedDrug.Buyprice);
                                CurTransactionId++;
                                TransactionsList.Add(new(CurTransactionId, selectedDrug.Name, buyEliminateCount, Math.Round(-(selectedDrug.Buyprice*buyEliminateCount),2), "Покупка"));
                            }
                            else
                            {
                                ErrorBox.MoneyError();
                            }
                        }
                        
                    }
                    else
                    {
                        ErrorBox.DrugSelectError();
                    }
                }));
            }
        }
        public RelayCommand EliminateDrug 
        {
            get
            {
                return eliminateDrug ?? (eliminateDrug = new RelayCommand(obj =>
                {
                    if (selectedDrug != null)
                    {
                        if (buyEliminateCount <= 0)
                            ErrorBox.EliminateDrugCountError();
                        else
                        {
                            if (selectedDrug.Count == 0)
                            {
                                ErrorBox.DrugCountError();
                            }
                            else
                            {
                                if (buyEliminateCount > selectedDrug.Count)
                                {
                                    ErrorBox.EliminateDrugCountError();
                                }
                                else
                                {
                                    selectedDrug.Count = selectedDrug.Count - buyEliminateCount;
                                    CurTransactionId++;
                                    TransactionsList.Add(new(CurTransactionId, selectedDrug.Name, buyEliminateCount, Math.Round(-(selectedDrug.Buyprice*buyEliminateCount),2), "Списание"));
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        ErrorBox.DrugSelectError();
                    }

                }));
            }
        }

        public MainVM(IWindowService windowService)//, IWindowService windowService1, IWindowService windowService2)
        {
            login = "Логин";
            password = "Пароль";
            _windowService = windowService;
            //_windowService1 = windowService1;
            //_windowService2 = windowService2;
            DrugsList = new ObservableCollection<Drug>
            {
                new (CurDrugId, "name", "symptoms", 1, 50, 20),
                new (CurDrugId+1, "name2", "symptoms2", 50, 150, 75)
            };
            CurDrugId++;
            TransactionsList = new ObservableCollection<Transaction>
            {
                new (CurTransactionId, "name", 3, 150, "Продажа")
            };
        }
    }
}
