using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.Model.Base
{
    public class PropertyChange : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
