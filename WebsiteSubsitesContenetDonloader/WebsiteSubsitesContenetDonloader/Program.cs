﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleApplicationTest
{
  public static class Program
  {
    static void Main(string[] args)
    {
      string result = string.Empty;
      // Welcome message
      Console.WriteLine("____Welcome Website Images Downloader____\n");
      Console.Write("Please enter the website path: ");
      string path = Console.ReadLine();


      // Checking URL validity

      if (!Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
      { Console.WriteLine("Wrong URL path!!!"); }

      else
      {   // Creating strings for operations
        string all = string.Empty;
        string htmlCode = string.Empty;

        using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
        {
          htmlCode = client.DownloadString(path);
          result += htmlCode;
          all = showMatch(htmlCode, @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)");
          Console.WriteLine("_-------------");
          string[] urls = all.Split(new Char[] { '\n' });

          foreach (string str in urls)
          {
            htmlCode = client.DownloadString(str);
            result += str+ ":\n" +htmlCode;
          }
        }
      }

      Console.WriteLine(result);
      Console.ReadKey();
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
}