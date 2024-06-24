using BornToMove.Business;
using BornToMove.DAL;

namespace BornToMove
{
    class Program
    {
        static void Main(string[] args)
        {
            MoveCrud moveCrud = new MoveCrud(new MoveContext());
            BuMove businessMove = new BuMove(moveCrud);

            Controller controller = new Controller(businessMove);
            controller.RunProgram();
        }
    }
}