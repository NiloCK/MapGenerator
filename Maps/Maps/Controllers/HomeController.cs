using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuggestionSniffer;

namespace Maps.Controllers
{
    public class HomeController : Controller
    {
        WebClient client = new WebClient();
        
        // GET: Home
        public ActionResult Index(String Query)
        {
            ViewBag.Query = Query;
            ViewBag.Results = Sniffer.StateSuggestions(Query);

            return View();
        }

        public ActionResult Suggestion(String Query)
        {
            return Content(Sniffer.BestResult(Query));
        }

    }
}