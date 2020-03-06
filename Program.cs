using System;
using System.Text.RegularExpressions;


namespace Chisel
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runtime = true;
            var t = new helpText();
            t.intro();
            while (runtime == true)
            {
                Console.Write("--> ");
                string address = Console.ReadLine();
                string prefix = "https://";
                string suffix = "";

                //decision tree to figure out what do do with the address
                if (address != "-HELP" && address != "-EXIT" && address != "")
                {
                    //syntactical address checking
                    string testAddressValid = string.Concat(prefix, address);
                    bool isUri = Uri.IsWellFormedUriString(testAddressValid, UriKind.RelativeOrAbsolute);

                    //test the connection
                    var q = new connTest();
                    int pingResult = q.PingHost(testAddressValid);
                    if (isUri == true && pingResult == 10)
                    {
                        Console.WriteLine("ATTEMPTING TO EXECUTE SCRAPE ON WEBPAGE.");
                        Console.Write("USING: ");
                        string coachaddress;
                        coachaddress = String.Concat(prefix, address, suffix);
                        Console.Write(coachaddress);



                        Console.WriteLine("SCRAPE IS WIP.")
                        //KEEP THIS IN so that the next query displays correctly...
                        Console.Write("\n");
                    }
                    else
                    {
                        // return statuses
                        // code 10: ping success
                        // code 11: timeout
                        // code 12: ping exception
                        // code 13: no interconnection found
                        // code 14: failure for unknown reason
                        // code 15: socket exception
                        if (pingResult == 11)
                        {
                            Console.WriteLine("ERROR 11. PING TIMEOUT.");
                            Console.WriteLine("\n");
                        }
                        else if (pingResult == 12)
                        {
                            Console.WriteLine("ERROR 12. PING EXCEPTION THROWN.");
                            Console.WriteLine("\n");
                        }
                        else if (pingResult == 13)
                        {
                            Console.WriteLine("ERROR 13. UNABLE TO ESTABLISH INTERNET LINK. CHECK INTERNET CONNECTION.");
                            Console.WriteLine("\n");
                        }
                        else if (pingResult == 14)
                        {
                            Console.WriteLine("ERROR 14. PING FAILURE. UNKNOWN REASON.");
                            Console.WriteLine("\n");
                        }
                        else if (pingResult == 15)
                        {
                            Console.WriteLine("ERROR 15. SOCKET EXCEPTION THROWN.");
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            Console.WriteLine("ERROR 21. INVALID ADDRESS.");
                            Console.Write("\n");
                        }
                    }
                }
                else if (address == "-HELP")
                {
                    t.help();
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
