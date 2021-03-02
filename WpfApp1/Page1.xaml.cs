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
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private int hauteur;
        private int largeur;
        private int poids;
        ColumnDefinition colDef;
        RowDefinition rowDef;
        TextBox textBox;
        DataTable dt;

        public Page1(int hauteur, int largeur, int poids)
        {
            InitializeComponent();

            this.hauteur = hauteur;
            this.largeur = largeur;
            this.poids = poids;

            CreateGrid();
        }

        public void CreateGrid()
        {
            //for(int i = 0; i < hauteur; i++)
            //{

            //}
            Trace.WriteLine("heyy");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            colDef = new ColumnDefinition();
            rowDef = new RowDefinition();
            textBox = new TextBox();
            // DataTable dt = new DataTable();

            myGrid.ColumnDefinitions.Add(colDef);
            myGrid.RowDefinitions.Add(rowDef);
            myGrid.ShowGridLines = true;
            Trace.WriteLine(myGrid.ColumnDefinitions.ElementAt(0));
            Trace.WriteLine(colDef);

            //textBox = new TextBox();
            //textBox.Text = "Author Name";
            //textBox.FontSize = 14;
            //textBox.FontWeight = FontWeights.Bold;
            //textBox.Foreground = new SolidColorBrush(Colors.Green);
            //textBox.VerticalAlignment = VerticalAlignment.Top;
            //Grid.SetRow(textBox, 1);
            //Grid.SetColumn(textBox, 2);
            //Trace.WriteLine(textBox);
            //Trace.WriteLine("aaaaaaa");

        }
    }
}
