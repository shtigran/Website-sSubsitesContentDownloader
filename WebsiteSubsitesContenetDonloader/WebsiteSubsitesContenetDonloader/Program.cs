using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteSubsitesContentDownloader
{
  class Program
  {
    static void Main(string[] args)
    {
      // Welcome message
      Console.WriteLine("____Welcome Website Content Downloader____\n");
      Console.Write("Please enter the website path: ");
      string path = Console.ReadLine();

      // Checking URL validity

      if (!Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
      { Console.WriteLine("Wrong URL path!!!");
      }

      else
      {   // Creating strings for operations
        string all = string.Empty;
        string htmlCode = string.Empty;





        Console.ReadKey();
    }
  }
}
