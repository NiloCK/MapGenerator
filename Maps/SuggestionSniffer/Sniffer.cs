using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuggestionSniffer
{
    public class Sniffer
    {
        public static List<String> Extensions(String Query)
        {
            var ret = new List<String>();
            if (String.IsNullOrEmpty(Query))
            {
                return ret;
            }
            
            if (!Query.Contains("{state}"))
            {
                ret.Add("Query must contain {state}");
                return ret;
            }
            

            foreach (var state in states.Values)
            {
                String json = JSONString(Query.Replace("{state}", state));
                ret.Add(json);
                // todo parse object and get best extension etc etc
            }
            //testchange
            return ret;
        }

        public static String Suggestion(String Query)
        {
            String json = JSONString(Query);
            //JsonConverter
            
            
            
            return null;
        }
        
        /// <summary>
        /// Google API for autocomplete suggestions as 'documented' at
        /// http://stackoverflow.com/questions/6428502/google-search-autocomplete-api
        /// </summary>
        /// <param name="Query">The 'user text' on which to provide suggestions</param>
        /// <returns>Raw string of JSON object containing suggestions.</returns>
        public static String JSONString(String Query)
        {
            WebRequest req = WebRequest.CreateHttp("http://suggestqueries.google.com/complete/search");
            req.Method = "GET";

            WebClient client = new WebClient();
            client.QueryString = new System.Collections.Specialized.NameValueCollection(2);
            client.QueryString.Add("client", "chrome");
            client.QueryString.Add("q", Query);

            using (Stream data = client.OpenRead("http://suggestqueries.google.com/complete/search"))
            {
                using (StreamReader reader = new StreamReader(data))
                {
                    return reader.ReadLine();
                }
            }
        }

        class SuggestionResult
        {
            public String Query { get; set; }
            public List<String> Suggestions { get; set; }
            public List<int> Scores { get; set; }
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
    public static class Extensions
    {
        public static int Nth(this String str, int n, String s)
        {
            int count = 0;
            int ret = -1;
            string replacement = s;
            
            replacement = replacement.ToUpper();

            if (replacement.Equals(s)){
                char first = replacement.ElementAt(0);
                replacement.Replace(first, ++first);
            }

            while (count < n){
                ret = str.IndexOf(s);
                //todo : str.ReplaceFirst(s,replacement)
                count++;
            }

            return ret;
        }
    }
}
