using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace WpfApp1.ViewModels
{
    public class Labyrinth
    {
        private int Hauteur;
        private int Largeur;
        private int Poids;
        private Node[,] Graph;
        private Branch[,] Branches;

        public Labyrinth(int hauteur, int largeur, int poids)
        {
            Hauteur = hauteur;
            Largeur = largeur;
            int nbrArete = 2 * (hauteur * largeur) - hauteur - largeur;
            Poids = poids;
            Graph = new Node[(hauteur + (hauteur - 1)), (largeur + (largeur - 1))];
            Trace.WriteLine((hauteur + (hauteur - 1)));
        }

        public void CreateLab()
        {
            int nbNodes = Hauteur * Largeur;
            int nbrArete = 2 * (Hauteur * Largeur) - Hauteur - Largeur;
            int position = 0;

            // Loop qui permet de parcourir le graph
            for(int i = 0; i < Hauteur; i++)
            {
                for(int j = 0; j < Largeur; j++)
                {
                    Graph[i, j] = new Node(i, j, Hauteur, Largeur, Poids, position);
                    position++;
                }
            }

            for (int i = 0; i < nbrArete; i++)
            {
                Branch branch = new Branch();
            }
        }
    }
}
