using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Drugstore_Application.Services
{
    public class ToMainWindowService : IWindowService
    {
        public void CloseWindow()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault (win => win.IsActive);
            if (window != null) { window.Close(); }
        }

        public void OpenWindow()
        {
            var window = new MainWindow();
            window.ShowDialog();
        }
    }
}
