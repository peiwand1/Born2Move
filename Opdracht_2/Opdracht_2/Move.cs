namespace BornToMove
{
    public class Move
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int sweatRate { get; set; }

        public Move(int anId, string aName,  string aDescription, int aSweatRate) 
        {
            id = anId;
            name = aName;
            description = aDescription;
            sweatRate = aSweatRate;
        }
    }
}
