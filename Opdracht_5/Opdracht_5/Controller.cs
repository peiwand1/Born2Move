using BornToMove.Business;
using BornToMove.DAL;
using Sort_opdracht;

namespace BornToMove
{
    // Lets you swap between using db id column and a newly generated id based on position in list
    // Good for when rows have been deleted and there are gaps in the ids
    enum IdMode
    {
        useListIndex,
        useDBIndex
    }

    internal class Controller
    {
        private RotateSort<Move> sorter;
        private IComparer<Move> comparer;
        private BuMove buMove;
        private IdMode idMode;

        public Controller(BuMove aBuMove, MoveContext context)
        {
            sorter = new RotateSort<Move>();
            buMove = aBuMove;
            idMode = IdMode.useListIndex;
            comparer = new MoveComparer(context);
            buMove.populateDB(); // adds some moves (if the db is empty)
        }

        public void RunProgram()
        {
            List<Move> moves = buMove.getMoves();
            if (UserWantsChoice())
            {
                moves = sorter.Sort(moves, comparer);
                moves.Reverse();

                Console.Clear();
                ShowMoves(moves, idMode);

                int id = ChooseMove();
                Console.Clear();

                if (id == 0)
                {
                    AddNewMove();
                }
                else
                {
                    Move m = FindMove(moves, id, idMode);
                    ShowMove(m);
                    GiveRating(m);
                }
            }
            else
            {
                Console.Clear();
                Random rand = new Random();
                Move m = moves[rand.Next(0, moves.Count)];
                ShowMove(m);
                GiveRating(m);

            }
        }

        /**
         * asks user if they want to choose an excersice on their own
         * y and Y are considered a yes, other input is considered a no
         */
        private bool UserWantsChoice()
        {
            Console.WriteLine("Get schmoving!");
            Console.WriteLine("Do you want to choose your own exercise? (y/n)");
            string? input = Console.ReadLine();
            return string.Equals(input, "y", StringComparison.OrdinalIgnoreCase);
        }

        /**
         * asks the user to choose a move by id
         */
        private int ChooseMove()
        {
            Console.WriteLine("\nWhich will you choose? Enter 0 to add a new move");
            int id = 0;
            string? ageInput = Console.ReadLine();
            if (!int.TryParse(ageInput, out id)) id = 1;
            return id;
        }

        /**
         * lists all moves in list
         * depending on IdMode it lists them with the objects ids or their List index
         */
        public void ShowMoves(List<Move> moves, IdMode mode)
        {
            Console.WriteLine("#   | " + "Name".PadRight(20, ' ') + "| Sweat rating | Avg rating");

            switch (mode)
            {
                case IdMode.useListIndex:
                    int i = 1;
                    foreach (Move move in moves)
                    {
                        Console.WriteLine((i.ToString() + ")").PadRight(4, ' ') + "| "
                                            + move.name.PadRight(20, ' ') + "| "
                                            //+ move.description + " "
                                            + move.sweatrate.ToString().PadRight(13, ' ') + "| "
                                            + buMove.getAvgMoveRating(move.id)
                                            );
                        i++;
                    }
                    break;
                case IdMode.useDBIndex:
                    foreach (Move move in moves)
                    {
                        Console.WriteLine((move.id.ToString() + ")").PadRight(4, ' ') + "| "
                                            + move.name.PadRight(20, ' ') + "| "
                                            //+ move.description + " "
                                            + move.sweatrate.ToString().PadRight(13, ' ') + "| "
                                            + buMove.getAvgMoveRating(move.id)
                                            );
                    }
                    break;
            }

        }

        /**
         * print Move data in console
         */
        public void ShowMove(Move move)
        {
            double? avgRating = buMove.getAvgMoveRating(move.id);
            Console.WriteLine(move.name + '\n'
                            + move.description + '\n'
                            + "Sweat rate: " + move.sweatrate + '\n'
                            + "Rating: " + (avgRating != null ? avgRating : "N/A")
                            );
        }

        /**
         * finds a Move from the given list
         * depending on IdMode it searches through the Move object's ids or their List index
         */
        public Move FindMove(List<Move> moves, int idToMatch, IdMode mode)
        {
            if (moves.Count == 0) return new Move(1, "Stand", "Just stand up from your desk for a bit", 1);

            switch (mode)
            {
                case IdMode.useListIndex:
                    int i = 1;
                    foreach (Move move in moves)
                    {
                        if (i == idToMatch) return move;
                        i++;
                    }
                    break;
                case IdMode.useDBIndex:
                    foreach (Move move in moves)
                    {
                        if (move.id == idToMatch) return move;
                    }
                    break;
            }

            Console.WriteLine("Could not find move with that ID, try this instead:");
            return moves[0];
        }

        /**
         * prompts user to add a new move to the database
         */
        public void AddNewMove()
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
                buMove.addMove(newMove);
                Console.WriteLine("New move has been added");
            }
            else
            {
                Console.WriteLine("Move was not added, please check input");
            }
        }

        private void GiveRating(Move move)
        {
            Console.WriteLine();
            Console.WriteLine("Done? How about giving a rating: (Between 1 and 10)");
            int rating = 0;
            string? ageInput = Console.ReadLine();
            if (!int.TryParse(ageInput, out rating)) return;
            if (rating > 10 || rating < 1) return;

            MoveRating mr = new MoveRating();
            mr.move = move;
            mr.rating = rating;
            mr.intensity = 1;
            buMove.addMoveRating(mr);

            Console.WriteLine("Added rating.");
        }
    }
}
