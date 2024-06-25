using BornToMove.Business;
using BornToMove.DAL;

namespace BornToMove
{
    class Program
    {
        static void Main(string[] args)
        {
            MoveContext context = new MoveContext();
            MoveCrud moveCrud = new MoveCrud(context);
            MoveRatingCrud moveRatingCrud = new MoveRatingCrud(context);
            BuMove businessMove = new BuMove(moveCrud, moveRatingCrud);

            Controller controller = new Controller(businessMove);
            controller.RunProgram();
        }
    }
}