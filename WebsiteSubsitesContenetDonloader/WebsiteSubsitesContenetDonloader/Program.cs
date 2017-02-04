using System;
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
      Console.WriteLine("____Welcome Website Content Downloader____\n");
            Console.WriteLine("The program download input Website and it's Subsites all content");
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
          Console.WriteLine("------------------------");
          Console.WriteLine($"\nThere are the following URLs in {path}: ");
                    Console.WriteLine("(Scanning and Downloading code) \n");
                    Console.ForegroundColor = ConsoleColor.Blue;

                    string[] urls = all.Split(new Char[] { '\n' });
                    string text = string.Empty;                  
                    urls[4] = "http://www.freenet.am/";
                   
                    for (int i = 0; i < urls.Length-1; i++)
                    {
                        Console.WriteLine($"URL {i+1}: {urls[i]}\n");
                        result += $"\n\n{urls[i]} \n {client.DownloadString(urls[i])} "; }
                }
            }
           
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\text.txt", result);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThe content of all Websites is Downloaded on Your Desktop in text.txt!!! ");
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