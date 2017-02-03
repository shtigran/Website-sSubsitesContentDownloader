using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

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

        using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
        {
          htmlCode = client.DownloadString(path);
          Console.WriteLine(htmlCode);
          all = showMatch(htmlCode, @"<(http)\b[^>]*>");
          Console.WriteLine("-------------");
          Console.WriteLine("\nThere are the following URLs: ");
          Console.WriteLine(all);
          string[] split = all.Split(new Char[] { '"', '?' });
          Console.WriteLine("-------------");
          string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
          WebClient client1;

        }

        Console.ReadKey();
      }
    }
    private static string showMatch(string text, string expr)
    {
      MatchCollection mc = Regex.Matches(text, expr);
      string result = "";
      foreach (Match m in mc)
      {
        result += m.ToString() + "\n";
      }
      return result;
    }
  }