using Drugstore_Application.Services;
using Drugstore_Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Drugstore_Application.View
{
    /// <summary>
    /// Логика взаимодействия для DrugChange.xaml
    /// </summary>
    public partial class DrugChange : Window
    {
        public DrugChange()
        {
            InitializeComponent();
            var windowService = new ToMainWindowService();
            //var windowService1 = new ToAddWindowService();
            //var windowService2 = new ToChangeWindowService();
            DataContext = new MainVM(windowService);//, windowService1, windowService2);
        }
    }
}
