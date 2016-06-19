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

        public ActionResult Play(WarViewModel vm)
        {
            return View(vm);
        }

        public ActionResult DrawCard(Hand playerOneHand, Hand playerTwoHand)
        {
            var hand = new Hand();
            HandResult result = hand.PlayGame(playerOneHand, playerTwoHand);
            return Play(new WarViewModel());
        }

        
    }
}