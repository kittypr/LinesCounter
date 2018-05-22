using System;
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

      bool multiline = false;
      foreach (var name in names)
      {
        try
        {
          using (StreamReader file = new StreamReader(name))
          {
            while ((line = file.ReadLine()) != null)
            {
              line = line.Trim();
              if (line.Length == 0) continue;
              if (line.StartsWith("//")) continue;
              if (line.Contains("/*"))
              {
                multiline = true;
                if (line.StartsWith("/*"))
                {
                  if (line.Contains("*/"))
                  {
                    if (line.EndsWith("*/"))
                    {
                      multiline = false;
                      continue;
                    }
                    multiline = false;
                  }
                  else continue;
                }
                else
                {
                  if (line.Contains("*/"))
                  {
                    multiline = false;
                  }
                }
              }
              if (line.Contains("*/"))
              {
                if (line.EndsWith("*/"))
                {
                  multiline = false;
                  continue;
                }
                multiline = false;
              }
              if (multiline) continue;
              counter++;
            }
          }
        }
        catch (UnauthorizedAccessException)
        {
        }
      }
      // Read the file and display it line by line.  


      System.Console.WriteLine("There were {0} lines.", counter);  
      // Suspend the screen.  
    }
  }
}