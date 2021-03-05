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
        ColumnDefinition colDef;
        RowDefinition rowDef;
        TextBox textBox;

        public Page1(int hauteur, int largeur, int poidsMax)
        {
            InitializeComponent();

            this.hauteur = hauteur;
            this.largeur = largeur;
            this.poidsMax = poidsMax;

            CreateGrid();
        }

        public void CreateGrid()
        {
            Labyrinth lab = new Labyrinth(hauteur, largeur, poidsMax);

            //List<List<bool>> lsts = new List<List<bool>>();
            //List<bool> lst1 = new List<bool>();
            //List<bool> lst2 = new List<bool>();
            //lst1.Add(true);
            //lst1.Add(false);
            //lst1.Add(true);
            //lst1.Add(true);
            //lst1.Add(true);

            //lst2.Add(true);
            //lst2.Add(false);
            //lst2.Add(true);
            //lst2.Add(true);
            //lst2.Add(true);

            //lsts.Add(lst1);
            //lsts.Add(lst2);
            lst.ItemsSource = lab.Prim();
            Style style = FindResource("lst") as Style;
            Trace.WriteLine(style);

        }
    }
}
