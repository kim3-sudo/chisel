using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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
        public string[] settingsParser()
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
                string settingsPath = string.Empty;
                settingsPath = Directory.GetCurrentDirectory() + @"\settings.xml";
                Console.WriteLine("[DEFAULT: settings.xml]");
                Console.Write("--> ");
                string newSettings = Console.ReadLine();
                Console.Write("\n");
                if (newSettings == "Y" || newSettings == "y" && newSettings != "-EXIT" && newSettings != "-HELP")
                {
                    //SPECIFY A NEW SETTINGS DOC
                    //assume settings doc is valid for now...will update during error checking.
                    validDoc = true;

                    Console.WriteLine("Specify new filename. Use full filepath.");
                    Console.Write("--> ");
                    string settingsFilename = string.Empty;
                    settingsFilename = Console.ReadLine();
                    settingsPath = Directory.GetCurrentDirectory() + settingsFilename;
                    settingsXDocFName = File.ReadAllText(settingsPath);
                    Console.Write("\n");
                    Console.Write("SETTINGS: ");
                    Console.Write(settingsXDocFName);

                    //put parsing code here
                    //load in the document
                    try
                    {
                        settingsXDoc.Load(settingsPath);
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
                    settingsPath = Directory.GetCurrentDirectory() + @"\settings\settings.xml";
                    settingsXDocFName = "settings.xml";
                    string settingsXml = string.Empty;

                    Console.Write("SETTINGS: ");

                    Console.Write(settingsPath);

                    //put parsing code here
                    //load in the document
                    try
                    {
                        settingsXDoc.Load(settingsPath);
                    }
                    catch
                    {
                        Console.WriteLine("\nERROR 30. SETTINGS FILE NOT FOUND.");
                        validDoc = false;
                    }

                    try
                    {
                        settingsXDoc.Load(settingsPath);

                        //store matching tags in new variables by node
                        XmlNodeList XmlPrefix = settingsXDoc.GetElementsByTagName("prefix");
                        XmlNodeList XmlSuffix = settingsXDoc.GetElementsByTagName("suffix");
                        XmlNodeList XmlMultFile = settingsXDoc.GetElementsByTagName("multfile");
                    }
                    catch
                    {
                        Console.WriteLine("\nERROR 31. SETTINGS FILE NOT VALID.");
                        validDoc = false;
                    }

                    try
                    {
                        settingsXDoc.Load(settingsPath);

                        //store matching tags in new variables by node
                        XmlNodeList XmlPrefix = settingsXDoc.GetElementsByTagName("prefix");
                        XmlNodeList XmlSuffix = settingsXDoc.GetElementsByTagName("suffix");
                        XmlNodeList XmlMultFile = settingsXDoc.GetElementsByTagName("multfile");

                        //convert XmlNodeList objects to strings
                        string prefix = XmlPrefix.ToString();
                        string suffix = XmlSuffix.ToString();
                        string MultFileString = XmlMultFile.ToString();
                    }
                    catch
                    {
                        Console.WriteLine("\nERROR 32. SETTINGS FILE NOT CONVERTABLE.");
                        validDoc = false;
                    }
                    

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
            string[] comboname = new string[3];
            comboname[0] = prefix;
            comboname[1] = suffix;
            comboname[2] = multFileString;
            return comboname;
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
