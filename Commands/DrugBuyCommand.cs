using Drugstore_Application.Model.Base;
using Drugstore_Application.Stores;
using Drugstore_Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.Commands
{
    public class DrugBuyCommand : CommandBase
    {
        private readonly DrugBuyEliminatePageVM _viewModel;
        private readonly NavigationStore _navigationStore;

        public DrugBuyCommand(DrugBuyEliminatePageVM viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedDrug != null)
            {
                if (_viewModel.BuyCount <= 0)
                    ErrorBox.BuyDrugCountError();
                else
                {
                    if ((_viewModel.Balance - _viewModel.BuyCount * _viewModel.SelectedDrug.Buyprice) >= 0)
                    {
                        _viewModel.SelectedDrug.Count = _viewModel.SelectedDrug.Count + _viewModel.BuyCount;
                        _viewModel.Balance = _viewModel.Balance - (_viewModel.BuyCount * _viewModel.SelectedDrug.Buyprice);
                        _viewModel.CurTransactionId++;
                        _viewModel.TransactionsList.Add(new(_viewModel.CurTransactionId, _viewModel.SelectedDrug.Name, _viewModel.BuyCount, Math.Round(-(_viewModel.SelectedDrug.Buyprice * _viewModel.BuyCount), 2), "Покупка"));
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
        }
    }
}
