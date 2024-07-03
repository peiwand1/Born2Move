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
        public IActionResult CreateMove([FromBody] Move move)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _buMove.addMove(move);
            return CreatedAtAction("Create", new { Id = move.id }, move);
        }

        //[HttpPost]
        //public IActionResult Rate(MoveRating rating) 
        //{
        //    // TODO
        //    return Details(rating.move.id);
        //}

        // TODO figure out how to make this happen without opening a new (empty) page
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
