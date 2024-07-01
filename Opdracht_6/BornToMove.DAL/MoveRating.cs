namespace BornToMove.DAL
{
    public class MoveRating
    {
        public int id { get; set; }
        public Move move { get; set; }
        public double rating { get; set; }
        public double intensity { get; set; }
    }
}
