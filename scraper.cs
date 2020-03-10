using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chisel
{
    class scraper
    {
        public string scraperInstance(string address, string scrapeClass)
        {
            try
            {
                Console.WriteLine("ATTEMPTING TO EXECUTE SCRAPE ON WEBPAGE.");
                Console.Write("USING: ");
                Console.Write(address);

                #region HtmlAgilityPack Scraper
                //reference: https://www.c-sharpcorner.com/article/web-scraping-in-c-sharp/

                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(address);

                var HeaderNames = doc.DocumentNode
                    .SelectNodes(scrapeClass).ToList();
                foreach (var item in HeaderNames)
                {
                    Console.WriteLine(item.InnerText);
                    return item.InnerText;
                }

                #endregion
            }
            catch
            {
                return "ERROR 40. UNKNOWN SCRAPING ERROR.";
            }
            return "ERROR 40. UNKNOWN SCRAPING ERROR.";
        }
    }
}
