﻿using BornToMove.Business;
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

        public IActionResult Details(int? id)
        {
            if (id == null) id = 1;
            MoveRating move = _buMove.getMoveAndAvgRatingById((int)id);// code om een enkele move op te halen met dit id inclusief de gemiddelde rating
            return View(move);
        }

        public IActionResult Random()
        {
            Move randomMove = _buMove.getRandomMove();// code om een random move op te halen
            MoveRating move = _buMove.getMoveAndAvgRatingById(randomMove.id);
            return View("Details", move);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMove(Move move)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _buMove.addMove(move);
            return RedirectToAction(nameof(Details), new { Id = move.id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rate(MoveRating moveRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            moveRating.move = _buMove.getMove(moveRating.move.id);

            _buMove.addMoveRating(moveRating);
            return RedirectToAction(nameof(Details), new { id = moveRating.move.id });
        }

        public IActionResult DeleteMove(int? id)
        {
            if (id == null) return BadRequest();

            if (_buMove.deleteMove((int)id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
