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
using Drugstore_Application.Stores;
using Drugstore_Application.ViewModel;

namespace Drugstore_Application
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new StartPageVM(navigationStore);
            DataContext = new MainVM(navigationStore);
        }
    }
}