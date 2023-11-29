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
    public class DrugAddCommand : CommandBase
    {
        private readonly DrugAddPageVM _viewModel;
        private readonly NavigationStore _navigationStore;

        public DrugAddCommand(DrugAddPageVM viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.AddName != null)
            {
                if (_viewModel.AddCount < 0 || _viewModel.AddPrice < 0 || _viewModel.AddBuyprice < 0)
                    ErrorBox.CountOrPriceError();
                else
                {
                    _viewModel.CurDrugId++;
                    _viewModel.DrugsList.Add(new(_viewModel.CurDrugId, _viewModel.AddName, _viewModel.AddSymptoms, _viewModel.AddCount, _viewModel.AddPrice, _viewModel.AddBuyprice));
                    _viewModel.BackToMain.Execute(true);
                }
            }
            else
                ErrorBox.NameError();
        }
    }
}
