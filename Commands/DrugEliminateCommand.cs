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
    public class DrugEliminateCommand : CommandBase
    {
        private readonly DrugBuyEliminatePageVM _viewModel;
        private readonly NavigationStore _navigationStore;

        public DrugEliminateCommand(DrugBuyEliminatePageVM viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedDrug != null)
            {
                if (_viewModel.EliminateCount <= 0)
                    ErrorBox.EliminateDrugCountError();
                else
                {
                    if (_viewModel.SelectedDrug.Count == 0)
                    {
                        ErrorBox.DrugCountError();
                    }
                    else
                    {
                        if (_viewModel.EliminateCount > _viewModel.SelectedDrug.Count)
                        {
                            ErrorBox.EliminateDrugCountError();
                        }
                        else
                        {
                            _viewModel.SelectedDrug.Count = _viewModel.SelectedDrug.Count - _viewModel.EliminateCount;
                            _viewModel.CurTransactionId++;
                            _viewModel.TransactionsList.Add(new(_viewModel.CurTransactionId, _viewModel.SelectedDrug.Name, _viewModel.EliminateCount, 0, "Списание"));
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
