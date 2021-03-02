using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModels
{
    public class DataList : ObservableCollection<Data>
    {
        public DataList() : base()
        {
            Add(new Data("allo", "bonjour"));
            Add(new Data("Salut", "Bye"));

        }
    }
    public class Data
    {
        private string test;
        private string test2;

        public Data(string test, string test2)
        {
            this.test = test;
            this.test2 = test2;
        }
    }
}
