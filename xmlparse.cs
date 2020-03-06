using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Chisel
{
    
    class xmlparse
    {
        string prefix;
        string suffix;

        public string MultFileString { get; private set; }
        //public object MultFile { get; private set; }

        string multFileString;
        bool multFile;
        //create a function called settingsParser that reads in the settings document and parses it
        public void settingsParser()
        {
            //initialize a new instance of the XmlDocument class
            XmlDocument settingsXDoc = new XmlDocument();

            //declare the settings file filename as a string
            string settingsXDocFName = "settings.xml";

            //force a valid settings doc
            bool validDoc = false;
            while (validDoc == false)
            {
                //does the user want to specify a new settings doc?
                Console.Write("\n");
                Console.WriteLine("Settings load. Specify new settings file? Y/n");
                Console.WriteLine("[DEFAULT: settings.xml]");
                Console.Write("--> ");
                string newSettings = Console.ReadLine();
                Console.Write("\n");
                if (newSettings == "Y" || newSettings == "y" && newSettings != "-EXIT" && newSettings != "-HELP")
                {
                    //assume settings doc is valid for now...will update during error checking.
                    validDoc = true;

                    Console.WriteLine("Specify new filename. Use full filepath.");
                    Console.Write("--> ");
                    settingsXDocFName = Console.ReadLine();
                    Console.Write("\n");
                    Console.Write("SETTINGS: ");
                    Console.Write(settingsXDocFName);

                    //put parsing code here
                    //load in the document
                    try
                    {
                        settingsXDoc.Load(settingsXDocFName);
                    }
                    catch
                    {
                        Console.WriteLine("\nERROR 30. SETTINGS FILE NOT FOUND.");
                        validDoc = false;
                    }

                    //store matching tags in new variables by node
                    XmlNodeList XmlPrefix = settingsXDoc.GetElementsByTagName("prefix");
                    XmlNodeList XmlSuffix = settingsXDoc.GetElementsByTagName("suffix");
                    XmlNodeList XmlMultFile = settingsXDoc.GetElementsByTagName("multfile");

                    //convert XmlNodeList objects to strings
                    prefix = XmlPrefix.ToString();
                    suffix = XmlSuffix.ToString();
                    MultFileString = XmlMultFile.ToString();

                    //convert multifle XML string to c# bool
                    bool MultFile;
                    if (MultFileString == "true")
                    {
                        MultFile = true;
                    }
                    else if (MultFileString == "false")
                    {
                        MultFile = false;
                    }
                }
                else if (newSettings == "N" || newSettings == "n" && newSettings != "-EXIT" && newSettings != "-HELP")
                {
                    //default settings doc is valid.
                    Console.Write("SETTINGS: ");
                    Console.Write(settingsXDocFName);

                    //put parsing code here
                    //load in the document
                    try
                    {
                        settingsXDoc.Load(settingsXDocFName);
                    }
                    catch
                    {
                        Console.WriteLine("\nERROR 30. SETTINGS FILE NOT FOUND.");
                        validDoc = false;
                    }

                    //store matching tags in new variables by node
                    XmlNodeList XmlPrefix = settingsXDoc.GetElementsByTagName("prefix");
                    XmlNodeList XmlSuffix = settingsXDoc.GetElementsByTagName("suffix");
                    XmlNodeList XmlMultFile = settingsXDoc.GetElementsByTagName("multfile");

                    //convert XmlNodeList objects to strings
                    string prefix = XmlPrefix.ToString();
                    string suffix = XmlSuffix.ToString();
                    string MultFileString = XmlMultFile.ToString();

                    //convert multifle XML string to c# bool
                    bool MultFile;
                    if (MultFileString == "true")
                    {
                        MultFile = true;
                    }
                    else if (MultFileString == "false")
                    {
                        MultFile = false;
                    }
                }
                else if (newSettings == "-HELP")
                {
                    var t = new helpText();
                    t.help();
                }
                else if (newSettings == "-EXIT")
                {
                    Console.WriteLine("BYE.");
                    Console.WriteLine("STRIKE ANY KEY TO CLOSE WINDOW.");
                    Console.ReadKey();
                    System.Environment.Exit(1);
                }
                else
                {
                    validDoc = false;
                    Console.Write("ERROR 22. INVALID SETTINGS DOCUMENT SET.");
                }
            } 
        }
        public string Prefix()
        {
            return prefix;
        }
        public string Suffix()
        {
            return suffix;
        }
        public bool MultFile()
        {
            return multFile;
        }
    }
}
