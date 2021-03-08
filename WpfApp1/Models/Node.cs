namespace WpfApp1.ViewModels
{
    public enum Side
    {
        Top,
        Bottom,
        Left,
        Right
    }

    public class Node
    {
        // La variable chosen sert à déterminer si il fait parti du chemin de solution
        public bool Chosen { get; set; }
        public int[] Position { get; set; }
        public int Id { get; set; }

        public Node(int i, int j, int id)
        {
            Id = id;
            Position = new int[] { i, j };
        }
    }
}
