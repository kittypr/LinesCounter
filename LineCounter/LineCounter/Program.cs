using System.IO;
using System.Text.RegularExpressions;

namespace LineCounter
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      string[] names = Directory.GetFiles(Directory.GetCurrentDirectory (), args[0], SearchOption.AllDirectories);
      int counter = 0;  
      string line;
      Regex comment = new Regex(@"^\s*//.*$");
      Regex spaces = new Regex(@"^\s*$");

      foreach (var name in names)
      {
        try
        {
          StreamReader file = new StreamReader(name);
          while ((line = file.ReadLine()) != null)
          {
            if (comment.IsMatch(line) | spaces.IsMatch(line)) continue;
            counter++;
          }

          file.Close();
        }
        catch (System.UnauthorizedAccessException)
        {
          
        }
      }
      // Read the file and display it line by line.  


      System.Console.WriteLine("There were {0} lines.", counter);  
      // Suspend the screen.  
    }
  }
}