using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class Controller
    {
        private List<Move> moves;

        public Controller()
        {
            moves = MoveCrud.GetInstance().SelectExercises();
        }

        public void RunProgram()
        {
            if (UserWantsChoice())
            {
                ShowMoves(moves);

                Console.WriteLine("\nWhich will you choose?");
                int id = 0;
                string? ageInput = Console.ReadLine();
                if (!int.TryParse(ageInput, out id)) id = 1;

                if (id == 0)
                {
                    AddNewMove();
                }
                else
                {
                    Console.WriteLine();
                    ShowMove(FindMove(moves, id));
                }
            }
            else
            {
                Random rand = new Random();
                ShowMove(moves[rand.Next(0, moves.Count)]);
            }
        }

        private bool UserWantsChoice()
        {
            Console.WriteLine("Get schmoving!");
            Console.WriteLine("Do you want to choose your own exercise? (y/n)");
            string? input = Console.ReadLine();
            return string.Equals(input, "y", StringComparison.OrdinalIgnoreCase);
        }

        public void ShowMoves(List<Move> moves)
        {
            Console.WriteLine("ID  | " + "Name".PadRight(20, ' ') + "| Sweat rating");
            foreach (Move move in moves)
            {
                Console.WriteLine((move.id.ToString() + ")").PadRight(4, ' ') + "| "
                                    + move.name.PadRight(20, ' ') + "| "
                                    //+ move.description + " "
                                    + move.sweatRate
                                    );
            }
        }

        public void ShowMove(Move move)
        {
            Console.WriteLine(move.name + '\n'
                            + move.description + '\n'
                            + "Sweat rate: " + move.sweatRate
                            );
        }

        public static Move FindMove(List<Move> moves, int idToMatch)
        {
            if (moves.Count == 0) return new Move(1, "Stand", "Just stand up from your desk for a bit", 1);

            foreach (Move move in moves)
            {
                if (move.id == idToMatch) return move;
            }

            Console.WriteLine("Could not find move with that ID, try this instead:");
            return moves[0];
        }

        public static void AddNewMove()
        {
            Console.WriteLine("Let's add a new move!");

            Console.WriteLine("Name:");
            string? name = Console.ReadLine();

            Console.WriteLine("Description:");
            string? description = Console.ReadLine();

            Console.WriteLine("Sweat rate: (Between 1 and 10)");
            int sweatrate = 0;
            string? sweatrateInput = Console.ReadLine();
            if (!int.TryParse(sweatrateInput, out sweatrate)) sweatrate = 0;

            if (name != null && description != null && sweatrate >= 1 && sweatrate <= 10)
            {
                Move newMove = new Move(0, name, description, sweatrate);
                MoveCrud.GetInstance().Insert(newMove);
                Console.WriteLine("New move has been added");
            }
        }
    }
}
