using BornToMove.DAL;

namespace BornToMove
{
    public class Move
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int sweatrate { get; set; }
        virtual public ICollection<MoveRating>? ratings { get; set; }

        public Move(int id, string name, string description, int sweatrate) 
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.sweatrate = sweatrate;
        }
    }
}
