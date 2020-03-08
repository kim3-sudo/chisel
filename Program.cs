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
            string prefix = readSettings.settingsParser()[0];
            string suffix = readSettings.settingsParser()[1];
            string multFileText = readSettings.settingsParser()[2];

            bool multFile;
            var toBool = new convertToBool();
            multFile = toBool.stringToBool(multFileText);

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
                        Console.WriteLine("ATTEMPTING TO EXECUTE SCRAPE ON WEBPAGE.");
                        Console.Write("USING: ");
                        string coachaddress;
                        coachaddress = String.Concat(prefix, address, suffix);
                        Console.Write(coachaddress);



                        Console.WriteLine("SCRAPE IS WIP.");
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
