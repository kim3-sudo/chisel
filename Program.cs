using System;
using System.Text.RegularExpressions;

namespace Chisel
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runtime = true;
            var showHelp = new helpText();
            showHelp.intro();

            //this should bring in the prefix and suffix, as well as multfile
            var readSettings = new xmlparse();
            string[] settingsArray = new string[3];
            settingsArray = readSettings.settingsParser();
            string prefix = settingsArray[0];
            string suffix = settingsArray[1];
            string multFileText = settingsArray[2];

            //let user that we're ready for scraping input
            Console.WriteLine("Ready for scraping input. Type '-HELP' for help.");

            while (runtime == true)
            {
                Console.Write("--> ");
                string address = Console.ReadLine();

                //decision tree to figure out what do do with the address
                if (address != "-HELP" && address != "-EXIT" && address != "")
                {
                    //syntactical address checking
                    string testAddressValid = string.Concat(prefix, address);
                    bool isUri = Uri.IsWellFormedUriString(testAddressValid, UriKind.RelativeOrAbsolute);

                    //test the connection
                    var testConn = new connTest();
                    int pingResult = testConn.PingHost(testAddressValid);
                    if (isUri == true && pingResult == 10)
                    {
                        string fulladdress = string.Empty;
                        fulladdress = String.Concat(prefix, address, suffix);
                        //Console.Write(fulladdress); //this bit's in the scraper.cs file

                        //call the scraper function
                        var beginScrape = new scraper();
                        beginScrape.scraperInstance(fulladdress);

                        //KEEP THIS IN so that the next query displays correctly...
                        Console.Write("\n");
                    }
                    else
                    {
                        var reportConnError = new connTestError();
                        reportConnError.pingErrorCode(pingResult);
                    }
                }
                else if (address == "-HELP")
                {
                    showHelp.help();
                }
                else if (address == "")
                {
                    Console.WriteLine("ERROR 20. NO INPUT DETECTED.");
                }
                else if (address == "-EXIT")
                {
                    runtime = false;
                    Console.WriteLine("BYE.");
                    Console.WriteLine("STRIKE ANY KEY TO CLOSE WINDOW.");
                    Console.ReadKey();
                    System.Environment.Exit(1);
                }
            }
        }
    }
}
