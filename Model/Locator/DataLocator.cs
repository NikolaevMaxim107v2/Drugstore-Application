using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.Model.Locator
{
    public class DataLocator
    {
        public DrugDataContainer DrugData { get; } = new DrugDataContainer();
        public TransactionDataContainer TransactionData { get; } = new TransactionDataContainer();
    }
}

