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
        private int buySellEliminateCount;
        private Drug selectedDrug;
        private IWindowService _windowService;
        private RelayCommand removeDrug;
        private RelayCommand addDrug;
        private RelayCommand buyDrug;
        private RelayCommand eliminateDrug;
        private RelayCommand sellDrug;
        private RelayCommand logIn;

        //Публичные переменные
        public ObservableCollection<Drug> DrugsList { get; set; }
        public ObservableCollection<Transaction> TransactionsList { get; set; }
        public ICommand OpenWindowCommand { get; set; }

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

        public double Balance { get { return Math.Round(balance,2); } set { balance = Convert.ToDouble(value); OnPropertyChanged(nameof(Balance)); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(nameof(Password)); } }
        public string Login { get => login; set { login = value; OnPropertyChanged(nameof(Login)); } }
        public string AddName { get => addName; set { addName = value; OnPropertyChanged(nameof(AddName)); } }
        public string AddSymptoms { get => addSymptoms; set { addSymptoms = value; OnPropertyChanged(nameof(AddSymptoms)); } }
        public int AddCount { get => addCount; set { addCount = value; OnPropertyChanged(nameof(AddCount)); } }
        public double AddPrice { get => addPrice; set { addPrice = value; OnPropertyChanged(nameof(AddPrice)); } }
        public double AddBuyprice { get => addBuyprice; set { addBuyprice = value; OnPropertyChanged(nameof(AddBuyprice)); } }
        public int BuySellEliminateCount { get => buySellEliminateCount;set { buySellEliminateCount = value; OnPropertyChanged(nameof(BuySellEliminateCount)); } }

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
                            TransactionsList.Add(new(CurTransactionId, selectedDrug.Name, selectedDrug.Count,0, "Списание"));
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
                }));
            }
        }

        public RelayCommand BuyDrug
        {
            get
            {
                return buyDrug ?? (buyDrug = new RelayCommand(obj =>
                {
                    if (selectedDrug != null)
                    {
                        if (buySellEliminateCount <= 0)
                            ErrorBox.BuyDrugCountError();
                        else
                        {
                            if ((balance - buySellEliminateCount * selectedDrug.Buyprice) >= 0)
                            {
                                selectedDrug.Count = selectedDrug.Count + buySellEliminateCount;
                                Balance = balance - (buySellEliminateCount * selectedDrug.Buyprice);
                                CurTransactionId++;
                                TransactionsList.Add(new(CurTransactionId, selectedDrug.Name, buySellEliminateCount, Math.Round(-(selectedDrug.Buyprice*buySellEliminateCount),2), "Покупка"));
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
                        if (buySellEliminateCount <= 0)
                            ErrorBox.EliminateDrugCountError();
                        else
                        {
                            if (selectedDrug.Count == 0)
                            {
                                ErrorBox.DrugCountError();
                            }
                            else
                            {
                                if (buySellEliminateCount > selectedDrug.Count)
                                {
                                    ErrorBox.EliminateDrugCountError();
                                }
                                else
                                {
                                    selectedDrug.Count = selectedDrug.Count - buySellEliminateCount;
                                    CurTransactionId++;
                                    TransactionsList.Add(new(CurTransactionId, selectedDrug.Name, buySellEliminateCount, 0, "Списание"));
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

        public RelayCommand SellDrug
        {
            get
            {
                return sellDrug ?? (sellDrug=new RelayCommand(obj=>
                {
                    if (selectedDrug!=null)
                    {
                        if (buySellEliminateCount <= 0)
                            ErrorBox.EliminateDrugCountError();
                        else
                        {
                            if (selectedDrug.Count == 0)
                            {
                                ErrorBox.DrugCountError();
                            }
                            else
                            {
                                if (buySellEliminateCount > selectedDrug.Count)
                                {
                                    ErrorBox.EliminateDrugCountError();
                                }
                                else
                                {
                                    selectedDrug.Count = selectedDrug.Count - buySellEliminateCount;
                                    Balance = Balance + (buySellEliminateCount * selectedDrug.Price);
                                    CurTransactionId++;
                                    TransactionsList.Add(new(CurTransactionId, selectedDrug.Name, buySellEliminateCount, Math.Round((selectedDrug.Price * buySellEliminateCount), 2), "Продажа"));
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

        public MainVM(IWindowService windowService)
        {
            login = "Логин";
            password = "Пароль";
            _windowService = windowService;
            DrugsList = new ObservableCollection<Drug>
            {
                new (CurDrugId, "Циклоферон 150 мг таблетки 20 шт", "Грипп и острые респираторные заболевания, герпетическая инфекция", 35, 589, 245),
                new (CurDrugId+1, "Золотая звезда бальзам мазь д/нар. прим.", "Головная боль, головокружение, насморк, укусы насекомых", 15, 179 , 89),
                new (CurDrugId+2, "Стрепсилс таб. д/рассас., 24 шт., лимон+мед", "Болевой синдром воспалительных заболеваний полости рта и ЛОР-органов, " +
                "боль в горле, инфекционно-воспалительные заболевания полости рта и глотки, ларингит, тонзиллит, фарингит", 7, 238 , 119),
                new (CurDrugId+3, "Уголь активированный таб., 250 мг, 20 шт.", "Диспепсические явления, лечение пищевых токсикоинфекций (ПТИ), энтеросорбирующее" +
                " средство для дезинтоксикации при экзо и эндогенных интоксикациях", 23, 34 , 17),
                new (CurDrugId+4, "Тантум верде спрей д/мест. прим. дозир., 0.255 мг/доза, 30 мл", "Болевой синдром воспалительных заболеваний полости рта и ЛОР-органов," +
                " гингивит, глоссит, инфекционно-воспалительные заболевания полости рта и глотки, калькулезное воспаление слюнных желез, кандидоз слизистой оболочки полости рта," +
                " ларингит, пародонтоз, после лечения и удаления зубов, стоматит, тонзиллит, фарингит", 27, 459 , 229),
                 new (CurDrugId+5, "Но-шпа таб., 40 мг, 64 шт.", "Головная боль, желудочно-кишечные спазмы, колит, первичная дисменорея, холангит, холецистит, цистит, энтероколит," +
                 " язвенная болезнь желудка и двенадцатиперстной кишки", 17, 393, 196),
            };
            CurDrugId+=5;
            TransactionsList = new ObservableCollection<Transaction>
            {
                new (CurTransactionId, "Тантум верде спрей д/мест. прим. дозир., 0.255 мг/доза, 30 мл", 3, 1377, "Продажа"),
                new (CurTransactionId+1, "Золотая звезда бальзам мазь д/нар. прим.", 5, -895, "Покупка"),
                new (CurTransactionId+2, "Уголь активированный таб., 250 мг, 20 шт.", 7, 0, "Списание"),
                new (CurTransactionId+3, "Но-шпа таб., 40 мг, 64 шт.", 3, 1179, "Продажа"),
                new (CurTransactionId+4, "Стрепсилс таб. д/рассас., 24 шт., лимон+мед", 3, 0, "Списание"),
            };
            CurTransactionId+=4;
        }
    }
}
