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

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            string[] names = propertyName.Split("\\/\r \n()\"\'-".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            switch (names.Length)
            {
                case 0: PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); break;
                case 1:
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                    break;
                default:
                    OnPropertyChanged(names);
                    break;
            }

        }

        public void OnPropertyChanged(IEnumerable<string> propList)
        {
            foreach (string propertyName in propList.Where(name => !string.IsNullOrWhiteSpace(name)))
                OnPropertyChanged(propertyName);
        }

        public void OnAllPropertyChanged()
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));

        protected virtual void SetProperty<T>(ref T fieldProperty, T newValue, [CallerMemberName] string propertyName = "")
        {
            if ((fieldProperty != null && !fieldProperty.Equals(newValue)) || (fieldProperty == null && newValue != null))
                PropertyNewValue(ref fieldProperty, newValue, propertyName);
        }

        protected virtual void PropertyNewValue<T>(ref T fieldProperty, T newValue, string propertyName)
        {
            fieldProperty = newValue;
            OnPropertyChanged(propertyName);
        }
    }
}
