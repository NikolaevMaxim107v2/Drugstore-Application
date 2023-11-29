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
    public class DrugRemoveCommand : CommandBase
    {
        private readonly MainPageVM _viewModel;
        private readonly NavigationStore _navigationStore;

        public DrugRemoveCommand(MainPageVM viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedDrug != null)
            {
                if (_viewModel.SelectedDrug.Count > 0)
                {
                    _viewModel.CurTransactionId++;
                    _viewModel.TransactionsList.Add(new(_viewModel.CurTransactionId, _viewModel.SelectedDrug.Name, _viewModel.SelectedDrug.Count, 0, "Списание"));
                }
                _viewModel.DrugsList.Remove(_viewModel.SelectedDrug);
                _viewModel.TextSearchDrug = null;
            }
            else
                ErrorBox.DrugSelectError();
        }
    }
}
