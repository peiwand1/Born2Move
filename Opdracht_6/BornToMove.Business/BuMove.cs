using BornToMove.DAL;

namespace BornToMove.Business
{
    public class BuMove
    {
        MoveCrud moveCrud;
        MoveRatingCrud moveRatingCrud;

        public BuMove(MoveCrud aMoveCrud, MoveRatingCrud aMoveRatingCrud)
        {
            moveCrud = aMoveCrud;
            moveRatingCrud = aMoveRatingCrud;
        }

        public Move getRandomMove()
        {
            List<Move> moves = getMoves();
            Random r = new Random();
            return moves.ElementAt(r.Next(0, moves.Count()));
        }

        public List<Move> getMoves()
        {
            return moveCrud.readAllMoves();
        }

        public Move getMove(int id)
        {
            return moveCrud.readMoveById(id);
        }

        public List<MoveRating> getMovesWithAvgRating()
        {
            return moveRatingCrud.readAllMoveAvgRatings();
        }

        public MoveRating getMoveAndAvgRatingById(int id)
        {
            return moveRatingCrud.readAvgMoveRatingByMoveId(id);
        }

        public double? getAvgMoveRating(int id)
        {
            return moveRatingCrud.readAvgMoveRatingValueByMoveId(id);
        }

        public void addMove(string name, string description, int sweatrate)
        {
            Move move = new Move(0, name, description, sweatrate);
            moveCrud.create(move);
        }

        public void addMoveRating(MoveRating moveRating)
        {
            moveRatingCrud.create(moveRating);
        }

        public void updateMove(Move move)
        {
            moveCrud.update(move);
        }

        public void populateDB()
        {
            if (getMoves().Count() == 0)
            {
                addMove("Push up", "Ga horizontaal liggen op teentoppen en handen. Laat het lijf langzaam zakken tot de neus de grond bijna raakt. Duw het lijf terug nu omhoog tot de ellebogen bijna gestrekt zijn. Vervolgens weer laten zakken. Doe dit 20 keer zonder tussenpauzes", 3);
                addMove("Planking", "Ga horizontaal liggen op teentoppen en onderarmen. Houdt deze positie 1 minuut vast", 3);
                addMove("Squat", "Ga staan met gestrekte armen. Zak door de knieën tot de billen de grond bijna raken. Ga weer volledig gestrekt staan. Herhaal dit 20 keer zonder tussenpauzes", 5);
            }
        }
    }
}
