using Drugstore_Application.Model;
using Drugstore_Application.Model.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.Stores
{
    public class TransactionsListStore : PropertyChange
    {
        private ObservableCollection<TransactionDS> _transactionsList;
        public int CurTransactionId = 0;

        public ObservableCollection<TransactionDS> TransactionsList { get => _transactionsList; set { _transactionsList = value; OnTransactionsListChanged(); } }

        public TransactionsListStore() 
        {
            TransactionsList = new ObservableCollection<TransactionDS>
            {
                new (CurTransactionId, "Тантум верде спрей д/мест. прим. дозир., 0.255 мг/доза, 30 мл", 3, 1377, "Продажа"),
                new (CurTransactionId+1, "Золотая звезда бальзам мазь д/нар. прим.", 5, -895, "Покупка"),
                new (CurTransactionId+2, "Уголь активированный таб., 250 мг, 20 шт.", 7, 0, "Списание"),
                new (CurTransactionId+3, "Но-шпа таб., 40 мг, 64 шт.", 3, 1179, "Продажа"),
                new (CurTransactionId+4, "Стрепсилс таб. д/рассас., 24 шт., лимон+мед", 3, 0, "Списание"),
            };
            CurTransactionId += 4;
        }

        public event Action TransactionsListChanged;

        private void OnTransactionsListChanged()
        {
            TransactionsListChanged?.Invoke();
        }
    }
}
