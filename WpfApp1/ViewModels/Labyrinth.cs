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
        public Node[,] NodeGraph { get; set; }
        private Branch[,] Branches;
        public bool[,] Result { get; }
        private int NbArete;
        private int GrandeurReelle;
        private int NbNodes;
        private dynamic[,] Graph;

        public Labyrinth(int hauteur, int largeur, int poids)
        {
            Hauteur = hauteur;
            Largeur = largeur;
            Poids = poids;
            

            Graph = new dynamic[(hauteur + (hauteur - 1)), (largeur + (largeur - 1))];
            Result = new bool[(hauteur + (hauteur - 1)), (largeur + (largeur - 1))];

            //Hauteur = hauteur;
            //Largeur = largeur;
            //NbArete = 2 * (hauteur * largeur) - hauteur - largeur;
            //GrandeurReelle = (hauteur + (hauteur - 1)) * (largeur + (largeur - 1));
            //Poids = poids;
            //// Graph = new Node[(hauteur + (hauteur - 1)), (largeur + (largeur - 1))];
            //NodeGraph = new Node[hauteur, largeur];

            CreateNodes();
            CreateBranches();
        }

        private void CreateNodes()
        {
            int id = 0;
            for (int i = 0; i < Hauteur + (Hauteur - 1); i += 2)
            {
                for (int j = 0; j < Largeur + (Largeur - 1); j += 2)
                {
                    Graph[i, j] = new Node(i, j, id);
                    id++;
                }
            }


            //// Loop qui permet de parcourir le graph
            //for (int i = 0; i < Hauteur; i++)
            //{
            //    for (int j = 0; j < Largeur; j++)
            //    {

            //        // NodeGraph[i, j] = new Node(i, j, Hauteur, Largeur);
            //        // On fait des sauts de deux, car entre chaque node il va y avoir une branche.
            //    }
            //}
        }

        private void CreateBranches()
        {
            Random rnd = new Random();
            for (int i = 0; i < Hauteur + (Hauteur - 1); i++)
            {
                int start = i % 2 == 1 ? 0 : 1;
                for (int j = start; j < Largeur + (Largeur - 1) ; j += 2)
                {
                    int v = rnd.Next(0, Poids);
                    Graph[i, j] = new Branch(i, j, v);
                }
            }


            //int id = 0;
            //for (int k = 0; k < Hauteur; k++)
            //{
            //    for (int i = 0; i < Largeur; i++)
            //    {
            //        // Creation des branches et assignations des branches aux nodes
            //        // horizontal
            //        Random rnd = new Random();
            //        Branch branch = new Branch(rnd.Next(0, Poids));
            //        Branch branch1 = new Branch(rnd.Next(0, Poids));


            //        if (NodeGraph[k, i].Sides.Contains(Side.Right))
            //        {
            //            branch.Position[0] = k;
            //            branch.Position[1] = i + 1;
            //            NodeGraph[k, i].BranchList.Add(branch);
            //        }
            //        if (NodeGraph[k, i].Sides.Contains(Side.Top))
            //        {
            //            // va chercher la branche de l'autre node au dessus de lui
            //            NodeGraph[k, i].BranchList.Add(NodeGraph[k - 1, i].BranchList.ElementAt(1));
            //        }
            //        if (NodeGraph[k, i].Sides.Contains(Side.Bottom))
            //        {
            //            branch1.Position[0] = k + 1;
            //            branch1.Position[1] = i;
            //            NodeGraph[k, i].BranchList.Add(branch1);
            //        }
            //        if (NodeGraph[k, i].Sides.Contains(Side.Left))
            //        {
            //            // va chercher la branche de l'autre node à gauche de lui
            //            NodeGraph[k, i].BranchList.Add(NodeGraph[k, i - 1].BranchList.ElementAt(0));
            //        }
            //    }
            //}
        }

        public List<List<bool>> Prim()
        {
            List<Node> visitedNode = new List<Node>();
            Result[0, 0] = true;
            visitedNode.Add(Graph[0, 0]);
            Graph[0, 0].Chosen = true;
            Branch branch = null;
            int direction = 0;

            while (visitedNode.Count < Hauteur * Largeur)
            {
                int branchWeight = Poids + 1; // Doit être plus haut pour automatiquement changer dès la première condition
                visitedNode.ForEach(node =>
                {

                    int i = node.Position[0];
                    int j = node.Position[1];

                    if (j + 1 < Largeur + (Largeur -1))
                    {
                        if (Graph[i, j + 1].Weight < branchWeight && !Graph[i, j + 1].Chosen && !Graph[i, j + 2].Chosen)
                        {
                            // Graph[i, j + 1].Chosen = true;
                            branch = Graph[i, j + 1];
                            direction = 1;
                            branchWeight = branch.Weight;
                        }
                    }
                    if(i + 1 < Hauteur + (Hauteur - 1))
                    {
                        if (Graph[i + 1, j].Weight < branchWeight && !Graph[i + 1, j].Chosen && !Graph[i + 2, j].Chosen)
                        {
                            branch = Graph[i + 1, j];
                            direction = 1;
                            branchWeight = branch.Weight;
                        }
                    }
                    if(i != 0)
                    {
                        if (Graph[i - 1, j].Weight < branchWeight && !Graph[i - 1, j].Chosen && !Graph[i - 2, j].Chosen)
                        {
                            branch = Graph[i - 1, j];
                            direction = -1;
                            branchWeight = branch.Weight;
                        }
                    }
                    if (j != 0)
                    {
                        if (Graph[i, j - 1].Weight < branchWeight && !Graph[i, j - 1].Chosen && !Graph[i, j - 2].Chosen)
                        {
                            branch = Graph[i, j - 1];
                            direction = -1;
                            branchWeight = branch.Weight;
                        }
                    }

                });

                // Évalue si la rangée de la branche.
                if (branch.Position[0] % 2 == 1)
                {
                    //// Évalue si le noeud qui est relié à la branche est déjà choisi.
                    //if (!Graph[branch.Position[0] + direction, branch.Position[1]].Chosen)
                    //{
                        visitedNode.Add(Graph[branch.Position[0] + 1, branch.Position[1]]);
                        Graph[branch.Position[0] + direction, branch.Position[1]].Chosen = true;
                        branch.Chosen = true;
                        Result[branch.Position[0], branch.Position[1]] = true;
                        Result[branch.Position[0] + direction, branch.Position[1]] = true;
                    // }
                }
                else
                {
                    //if (!Graph[branch.Position[0], branch.Position[1] + direction].Chosen)
                    //{
                        visitedNode.Add(Graph[branch.Position[0], branch.Position[1] + 1]);
                        Graph[branch.Position[0], branch.Position[1] + direction].Chosen = true;
                        branch.Chosen = true;
                        Result[branch.Position[0], branch.Position[1]] = true;
                        Result[branch.Position[0], branch.Position[1] + direction] = true;
                    //}
                }
                Trace.WriteLine(visitedNode.Count);
            }

            return ConvertToList(Result);
        }

        private List<List<bool>> ConvertToList(bool[,] result)
        {
            List<List<bool>> lists = new List<List<bool>>();
            for(int i=0; i < Hauteur + (Hauteur -1); i++)
            {
                List<bool> list = new List<bool>();
                for (int j = 0; j < Hauteur + (Hauteur - 1); j++)
                {
                    list.Add(result[i, j]);
                }
                lists.Add(list);
            }
            return lists;
        }


    }
}
