using BornToMove.Business;
using BornToMove.DAL;
using Sort_opdracht;

namespace BornToMove
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<double> list = new List<double>([3,4.2345,5.62346,6,7.8678,1,2,3,-4.54,53,6,4,5,6,7,8,9]);
            //IntComparer c = new IntComparer();
            //DoubleComparer d = new DoubleComparer();
            //RotateSort<double> s = new RotateSort<double>();

            //list = s.Sort(list, d);

            //foreach (double i in list)
            //{
            //    Console.WriteLine(i);
            //}

            MoveContext context = new MoveContext();
            MoveCrud moveCrud = new MoveCrud(context);
            MoveRatingCrud moveRatingCrud = new MoveRatingCrud(context);
            BuMove businessMove = new BuMove(moveCrud, moveRatingCrud);

            Controller controller = new Controller(businessMove);
            controller.RunProgram();
        }
    }
}