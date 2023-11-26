using Drugstore_Application.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.Model
{
    public class Drug : PropertyChange
    {
        private int _id;
        private string _name;
        private string _symptoms;
        private int _count;
        private double _price;
        private double _buyprice;

        public Drug(int id, string name, string symptoms, int count, double price, double buyprice)
        {
            Id = id;
            Name = name;
            Symptoms = symptoms;
            Count = count;
            Price = price;
            Buyprice = buyprice;
        }

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Symptoms { get { return _symptoms; } set { _symptoms = value; OnPropertyChanged(nameof(Symptoms)); } }
        public int Count { get { return _count; } set { _count = value; OnPropertyChanged(nameof(Count)); } }
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged(nameof(Price)); } }
        public double Buyprice { get { return _buyprice; } set { _buyprice = value; OnPropertyChanged(nameof(Buyprice)); } }
    }
}
