using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Drugstore_Application.ViewModel
{
    public abstract class ErrorBox
    {
        public static void DrugSelectError()
        {
            MessageBox.Show("Вы забыли выбрать медикамент из списка!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void DrugCountError()
        {
            MessageBox.Show("Данный медикамент закончился на складе!", "Ошибка количетсва", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public static void BuyDrugCountError()
        {
            MessageBox.Show("Введите корректное количество покупаемых медикаментов!", "Ошибка количетсва", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void EliminateDrugCountError()
        {
            MessageBox.Show("Введите корректное количество списываемых медикаментов!", "Ошибка количетсва", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void SellDrugCountError()
        {
            MessageBox.Show("Введите корректное количество продаваемых медикаментов!", "Ошибка количетсва", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void LogInError()
        {
            MessageBox.Show("Логин или пароль введены неверно, перепроверьте вводимые данные!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void DataTypeError()
        {
            MessageBox.Show("Данные введены неверно!", "Ошибка введённых данных", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void CountOrPriceError()
        {
            MessageBox.Show("В поля 'Цена' и(или) 'Количество' было(-и) введено(-ы) отрицательное(-ые) значение(-ия), пожалуйста, вводите только положительные значения!", "Ошибка введённых данных", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void NameError()
        {
            MessageBox.Show("Введите название!", "Ошибка введённых данных", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void MoneyError()
        {
            MessageBox.Show("На балансе недостаточно средств для покупки!", "Ошибка покупки", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
