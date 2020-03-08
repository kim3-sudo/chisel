using System;
using System.Collections.Generic;
using System.Text;

namespace Chisel
{
    class scraper
    {
        public string scraperInstance(string address)
        {
            try
            {
                Console.WriteLine("ATTEMPTING TO EXECUTE SCRAPE ON WEBPAGE.");
                Console.Write("USING: ");
                Console.Write(address);
            }
            catch
            {
                return "ERROR 40. UNKNOWN SCRAPING ERROR.";
            }
            return "ERROR 40. UNKNOWN SCRAPING ERROR.";
        }
    }
}
