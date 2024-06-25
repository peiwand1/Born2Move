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

        public double getAvgMoveRating(int id)
        {
            return moveRatingCrud.readAvgMoveRatingByMoveId(id);
        }

        public void addMove(Move move)
        {
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
                Move move1 = new Move(0, "Push up", "Ga horizontaal liggen op teentoppen en handen. Laat het lijf langzaam zakken tot de neus de grond bijna raakt. Duw het lijf terug nu omhoog tot de ellebogen bijna gestrekt zijn. Vervolgens weer laten zakken. Doe dit 20 keer zonder tussenpauzes", 3);
                Move move2 = new Move(0, "Planking", "Ga horizontaal liggen op teentoppen en onderarmen. Houdt deze positie 1 minuut vast", 3);
                Move move3 = new Move(0, "Squat", "Ga staan met gestrekte armen. Zak door de knieën tot de billen de grond bijna raken. Ga weer volledig gestrekt staan. Herhaal dit 20 keer zonder tussenpauzes", 5);
                addMove(move1);
                addMove(move2);
                addMove(move3);

                MoveRating r = new MoveRating();
                r.move = move1;
                r.rating = 1;
                r.intensity = 1;

                addMoveRating(r);

                r.rating = 4;
                addMoveRating(r);

            }
        }
    }
}
