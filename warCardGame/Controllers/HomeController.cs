using System;
using System.Collections.Generic;
using System.Web.Mvc;
using warCardGame.Classes;
using warCardGame.Models;

namespace warCardGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new WarViewModel());
        }

        public void Play(WarViewModel vm)
        {
            RedirectToAction("DrawCard");
        }

        public WarViewModel DrawCard(Hand playerOneHand, Hand playerTwoHand)
        {
            Random random = new Random();
            var hand = new Hand(Hand.generateRandom(26, random));
            HandResult result = hand.PlayGame(playerOneHand, playerTwoHand);
            return new WarViewModel();
        }
    }
}