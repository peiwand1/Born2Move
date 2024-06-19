using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace BornToMove
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get schmooving!");
            Console.WriteLine("Do you want to choose your own exercise? (y/n)");
            string? input = Console.ReadLine();
            input = string.Equals(input, "y", StringComparison.OrdinalIgnoreCase) ? "y" : "n";
            List<Move> moves = new List<Move>();

            // TODO choose random value if desired
            // TODO let user choose from lists if desired
            // TODO let user add new move to db by entering 0

            string connectionString = "server=(localdb)\\ProjectModels;database=born2move;";
            MoveCrud crud = new MoveCrud(connectionString);

            List<Move> results = crud.selectExercises();

            if (input.Equals("y"))
            {
                Console.WriteLine("ID  | " + "Name".PadRight(20, ' ') + "| Sweat rating");
                foreach (Move move in results)
                {
                    Console.WriteLine((move.id.ToString() + ")").PadRight(4, ' ') + "| "
                                        + move.name.PadRight(20, ' ') + "| "
                                        //+ move.description + " "
                                        + move.sweatRate
                                        );
                }

                int id = 0;
                string? ageInput = Console.ReadLine();
                if (!int.TryParse(ageInput, out id)) id = 1;
                Move m = findMove(moves, id);
                Console.WriteLine(m.id.ToString() + ")" + " | "
                                + m.name + " | "
                                + m.description + " "
                                + m.sweatRate
                                );
            }
        }

        public static Move findMove(List<Move> moves, int idToMatch)
        {
            foreach (Move move in moves)
            {
                if (move.id == idToMatch) return move;
            }

            Console.WriteLine("Could not find move with that ID, try this instead:");
            return moves[0];
        }
    }

}