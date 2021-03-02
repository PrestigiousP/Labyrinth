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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int hauteur;
        private int largeur;
        private int poids;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            hauteur = int.Parse(textBox.Text);
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            largeur = int.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            poids = int.Parse(textBox2.Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Content = new Page1(hauteur, largeur, poids);
        }
    }
}
