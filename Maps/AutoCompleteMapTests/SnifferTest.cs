using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuggestionSniffer;
using System.Diagnostics;
using Newtonsoft.Json;


namespace AutoCompleteMapTests
{
    [TestClass]
    public class SnifferTest
    {
        [TestMethod]
        public void JSONString()
        {
            for (int i = 0; i < 100; i++ )
                Debug.WriteLine("Hey"); // not writing.

            Debug.WriteLine(Sniffer.JSONString("where is"));
            // todo : pass this through a json validator I guess.
        }
    }
}
