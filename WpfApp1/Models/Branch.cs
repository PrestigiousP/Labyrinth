using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class Branch
    {
        public int Weight { get; set; }
        public bool Chosen { get; set; }
        public int Id { get; set; }
        public int[] Position { get; set; }


        public Branch(int i, int j, int poids)
        {
            Weight = poids;
            Position = new int[] { i, j };
        }
    }
}
