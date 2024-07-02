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
            Console.WriteLine("test got into function CreateMove");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("data was invalid");
                return BadRequest(ModelState);
            }

            Console.WriteLine("data: " + move.id + " " + move.name + " " + move.description + " " + move.sweatrate);

            _buMove.addMove(move);
            return CreatedAtAction("Create", new { Id = move.id }, move);
        }

        //[HttpPost]
        //public IActionResult Rate(MoveRating rating) 
        //{
        //    // TODO
        //    return Details(rating.move.id);
        //}
    }
}