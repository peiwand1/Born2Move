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
            Random r = new Random();
            return moveCrud.readMoveById(r.Next(0, moveCrud.readAllMoves().Count()));
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
            // TODO check data before adding
            moveCrud.create(move);
        }

        public void updateMove(Move move)
        {
            // TODO check data before updating
            moveCrud.update(move);
        }
    }
}
