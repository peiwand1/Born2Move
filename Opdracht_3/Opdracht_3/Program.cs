namespace BornToMove
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            controller.RunProgram();
            // TODO Pas het BornToMove project aan zodat het raadplegen van en wegschrijven naar de database voortaan via BornToMove.Business loopt.

        }
    }
}