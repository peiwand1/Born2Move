using BornToMove.Business;
using BornToMove.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BornToMove.ASPNET
{
    public class MovesController : Controller
    {
        private BuMove _buMove;
        public MovesController(BuMove buMove)
        {
            _buMove = buMove;
        }
        public IActionResult Index()
        {
            List<MoveRating> moves = _buMove.getMovesWithAvgRating();// code om de lijst met moves op te halen inclusief de gemiddelde rating
            return View(moves);
        }
        public IActionResult Details(int id)
        {
            MoveRating move = _buMove.getMoveAndAvgRatingById(id);// code om een enkele move op te halen met dit id inclusief de gemiddelde rating
            return View(move);
        }

        public IActionResult Random()
        {
            Move randomMove = _buMove.getRandomMove();// code om een random move op te halen

            return View("Details", new MoveRating { move = randomMove });
        }
    }
}
