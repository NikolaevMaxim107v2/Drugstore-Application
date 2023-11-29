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
    public class DrugSellCommand : CommandBase
    {
        private readonly DrugSellPageVM _viewModel;
        private readonly NavigationStore _navigationStore;

        public DrugSellCommand(DrugSellPageVM viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedDrug != null)
            {
                if (_viewModel.SellCount <= 0)
                    ErrorBox.SellDrugCountError();
                else
                {
                    if (_viewModel.SelectedDrug.Count == 0)
                    {
                        ErrorBox.DrugCountError();
                    }
                    else
                    {
                        if (_viewModel.SellCount > _viewModel.SelectedDrug.Count)
                        {
                            ErrorBox.SellDrugCountError();
                        }
                        else
                        {
                            _viewModel.SelectedDrug.Count = _viewModel.SelectedDrug.Count - _viewModel.SellCount;
                            _viewModel.Balance = _viewModel.Balance + (_viewModel.SellCount * _viewModel.SelectedDrug.Price);
                            _viewModel.CurTransactionId++;
                            _viewModel.TransactionsList.Add(new(_viewModel.CurTransactionId, _viewModel.SelectedDrug.Name, _viewModel.SellCount, Math.Round((_viewModel.SelectedDrug.Price * _viewModel.SellCount), 2), "Продажа"));
                        }
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
