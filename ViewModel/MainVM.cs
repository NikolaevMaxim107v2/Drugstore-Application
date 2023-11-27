using Drugstore_Application.Model;
using Drugstore_Application.Model.Base;
using Drugstore_Application.View;
using Drugstore_Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup.Localizer;

namespace Drugstore_Application.ViewModel
{
    public class MainVM : PropertyChange
    {
        public PropertyChange CurrentViewModel { get; }

        public MainVM()
        {
            //CurrentViewModel = new MainPageVM();
        }
    }
}
