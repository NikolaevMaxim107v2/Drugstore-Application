using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Drugstore_Application.Model;
using Drugstore_Application.ViewModel;
using Drugstore_Application.Services;

namespace Drugstore_Application
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var windowService = new ToMainWindowService();
            //var windowService1 = new ToAddWindowService();
            //var windowService2 = new ToChangeWindowService();
            DataContext = new MainVM(windowService);//, windowService1, windowService2);
        }
    }
}