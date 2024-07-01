namespace BornToMove.DAL;

public class Move : IComparable<Move>
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

    // compare Moves by their rating
    public int CompareTo(Move? other)
    {
        if (other == null) return 1;

        double? myAvg = ratings.Where(r => r.move.id == this.id)
                               .Average(r => r.rating);
        if (myAvg == null) return -1;

        double? otherAvg = ratings.Where(r => r.move.id == other.id)
                                  .Average(r => r.rating);
        if (otherAvg == null) return 1;

        if (myAvg > otherAvg) return 1;
        if (myAvg < otherAvg) return -1;
        return 0;
    }
}
