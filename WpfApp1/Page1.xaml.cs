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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private int hauteur;
        private int largeur;
        private int poidsMax;
        public List<List<bool>> ResultList { get; set; }

        public Page1(int hauteur, int largeur, int poidsMax)
        {
            InitializeComponent();

            this.hauteur = hauteur;
            this.largeur = largeur;
            this.poidsMax = poidsMax;

            Labyrinth lab = new Labyrinth(hauteur, largeur, poidsMax) { };
            ResultList = lab.Prim();
            lst.ItemsSource = ResultList;
        }
    }
}
