using System;
public class helpText
{
    public void intro()
    {
        Console.WriteLine("  ______  __    __   __       _______. _______  __ ");
        Console.WriteLine(" /      ||  |  |  | |  |     /       ||   ____||  |");
        Console.WriteLine("|  ,----'|  |__|  | |  |    |   (----`|  |__   |  |");
        Console.WriteLine("|  |     |   __   | |  |     \\   \\    |   __|  |  |");
        Console.WriteLine("|  `----.|  |  |  | |  | .----)   |   |  |____ |  `----.");
        Console.WriteLine(" \\______||__|  |__| |__| |_______/    |_______||_______|");
        Console.WriteLine("\n");
        Console.WriteLine("BEYOND MERCURY SOFTWARE DEVELOPMENT");
        Console.WriteLine("\n");
        Console.WriteLine("Please input the ROOT domain name to be scraped.");
        Console.WriteLine("Quit and write configuration changes to the .JSON file.");
        Console.WriteLine("For help, type '-HELP' and strike ENTER or RETURN.");
        Console.WriteLine("To quit, type '-EXIT' and strike ENTER or RETURN.");
    }
    public void help()
    {
        Console.WriteLine("CHISEL SOFTWARE PACKAGE");
        Console.WriteLine("\n");
        Console.WriteLine("To execute a page scrape, enter the root domain name of the athletics page");
        Console.WriteLine("to be scraped. Do not include any prefixes. For example, instead of: ");
        Console.WriteLine("\t 'https://hopkinssports.com/sports/mens-lacrosse/coaches'");
        Console.WriteLine("You should use: ");
        Console.WriteLine("\t 'hopkinssports.com'");
        Console.WriteLine("Do not include extra slashes, dashes, or colons at the end of the address.");
        Console.WriteLine("##### STRIKE ANY KEY TO VIEW THE NEXT PAGE #####");
        Console.ReadKey();
        Console.WriteLine("If you see '-->', you can type a command.");
        Console.WriteLine("To view this help, type '-HELP' and strike ENTER or RETURN.");
        Console.WriteLine("To quit, type '-EXIT' and strike ENTER or RETURN.");
        Console.WriteLine("For tech assistance, email *kim3@kenyon.edu*");
    }
}