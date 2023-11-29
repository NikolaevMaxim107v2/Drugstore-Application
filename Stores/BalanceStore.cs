using Drugstore_Application.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.Stores
{
    public class BalanceStore : PropertyChange
    {
        private double _balance;
        public double Balance { get => _balance; set { _balance = value; OnBalanceChanged(); } }

        public BalanceStore()
        {
            Balance = 50150;
        }

        public event Action BalanceChanged;

        private void OnBalanceChanged()
        {
            BalanceChanged?.Invoke();
        }
    }
}
