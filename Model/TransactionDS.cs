using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore_Application.Model.Base
{
    public class TransactionDS : PropertyChange
    {
        private int _id;
        private string _name;
        private int _count;
        private double _price;
        private string _type;

        public TransactionDS(int id, string name, int count, double price, string type)
        {
            Id = id;
            Name = name;
            Count = count;
            Price = price;
            Type = type;
        }

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public int Count { get { return _count; } set { _count = value; OnPropertyChanged(nameof(Count)); } }
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged(nameof(Price)); } }
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged(nameof(Type)); } }
    }
}
