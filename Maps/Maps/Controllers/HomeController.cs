﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Maps.Controllers
{
    public class HomeController : Controller
    {
        WebClient client = new WebClient();
        
        // GET: Home
        public ActionResult Index(String Query)
        {
            ViewBag.Query = Query;
            var results = new List<String>();

            foreach (var state in states.Values)
            {
                results.Add(BestAutoComplete(Query, state));
            }
            

            return View();
        }

        private string BestAutoComplete(String Query, String state)
        {
            
        }

        


        private static readonly IDictionary<string, string> states = new Dictionary<string, string>
        {
            { "AL", "Alabama" },
            { "AK", "Alaska" },
            { "AZ", "Arizona" },
            { "AR", "Arkansas" },
            { "CA", "California" },
            { "CO", "Colorado" },
            { "CT", "Connecticut" },
            { "DE", "Delaware" },
            { "DC", "District of Columbia" },
            { "FL", "Florida" },
            { "GA", "Georgia" },
            { "HI", "Hawaii" },
            { "ID", "Idaho" },
            { "IL", "Illinois" },
            { "IN", "Indiana" },
            { "IA", "Iowa" },
            { "KS", "Kansas" },
            { "KY", "Kentucky" },
            { "LA", "Louisiana" },
            { "ME", "Maine" },
            { "MD", "Maryland" },
            { "MA", "Massachusetts" },
            { "MI", "Michigan" },
            { "MN", "Minnesota" },
            { "MS", "Mississippi" },
            { "MO", "Missouri" },
            { "MT", "Montana" },
            { "NE", "Nebraska" },
            { "NV", "Nevada" },
            { "NH", "New Hampshire" },
            { "NJ", "New Jersey" },
            { "NM", "New Mexico" },
            { "NY", "New York" },
            { "NC", "North Carolina" },
            { "ND", "North Dakota" },
            { "OH", "Ohio" },
            { "OK", "Oklahoma" },
            { "OR", "Oregon" },
            { "PA", "Pennsylvania" },
            { "RI", "Rhode Island" },
            { "SC", "South Carolina" },
            { "SD", "South Dakota" },
            { "TN", "Tennessee" },
            { "TX", "Texas" },
            { "UT", "Utah" },
            { "VT", "Vermont" },
            { "VA", "Virginia" },
            { "WA", "Washington" },
            { "WV", "West Virginia" },
            { "WI", "Wisconsin" },
            { "WY", "Wyoming" }
        };
 
    }
}