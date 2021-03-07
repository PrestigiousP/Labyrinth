using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string hauteur;
        private string largeur;
        private string poidsMax;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidator(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            hauteur = textBox.Text;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            largeur = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            poidsMax = textBox2.Text;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int h = int.Parse(hauteur);
            int l = int.Parse(largeur);
            int p = int.Parse(poidsMax);

            Content = new Page1(h, l, p);
        }
    }
}
