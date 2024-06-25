using BornToMove.DAL;

namespace BornToMove.Business
{
    public class BuMove
    {
        MoveCrud moveCrud;

        public BuMove(MoveCrud aMoveCrud)
        {
            moveCrud = aMoveCrud;
        }

        public Move getRandomMove()
        {
            List<Move> moves = getMoves();
            Random r = new Random();
            return moves.ElementAt(r.Next(0, moves.Count()));
        }

        public List<Move> getMoves()
        {
            return moveCrud.readAllMoves().ToList();
        }

        public Move getMove(int id)
        {
            return moveCrud.readMoveById(id);
        }

        public void addMove(Move move)
        {
            moveCrud.create(move);
        }

        public void updateMove(Move move)
        {
            moveCrud.update(move);
        }

        public void populateDB()
        {
            if (getMoves().Count() == 0)
            {
                addMove(new Move(0, "Push up", "Ga horizontaal liggen op teentoppen en handen. Laat het lijf langzaam zakken tot de neus de grond bijna raakt. Duw het lijf terug nu omhoog tot de ellebogen bijna gestrekt zijn. Vervolgens weer laten zakken. Doe dit 20 keer zonder tussenpauzes", 3));
                addMove(new Move(0, "Planking", "Ga horizontaal liggen op teentoppen en onderarmen. Houdt deze positie 1 minuut vast", 3));
                addMove(new Move(0, "Squat", "Ga staan met gestrekte armen. Zak door de knieën tot de billen de grond bijna raken. Ga weer volledig gestrekt staan. Herhaal dit 20 keer zonder tussenpauzes", 5));
            }
        }
    }
}
