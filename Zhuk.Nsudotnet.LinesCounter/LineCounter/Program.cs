using System;
using System.IO;


namespace LineCounter
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      string[] names = Directory.GetFiles(Directory.GetCurrentDirectory (), args[0], SearchOption.AllDirectories);
      int counter = 0;  
      int symbol;
      Char prev;
      Char cur = '0';

      bool multiline = false;
      bool inline = false;
      bool wasMeaningful = false;
      foreach (var name in names)
      {
        try
        {
          using (StreamReader file = new StreamReader(name))
          {
            while (( symbol = file.Read()) != -1)
            {
              prev = cur;
              cur = (char) symbol;
              if (cur == '\n')
              {
                if (wasMeaningful)
                {
                  counter++;
                  wasMeaningful = false;
                  continue;
                }
                if (inline)
                {
                  inline = false;
                  continue;
                }
                if (multiline) continue;
              }
              if (Char.IsWhiteSpace(cur)) continue;
              if (cur == '/' && prev == '/')
              {
                inline = true;
                continue;
              }
              if (cur == '*' && prev == '/')
              {
                multiline = true;
                continue;
              }
              if (cur == '/' && prev == '*')
              {
                multiline = false;
                continue;
              }
              if (cur == '/' || cur == '*') continue;
              if (!inline && !multiline) wasMeaningful = true;
            }

            if (wasMeaningful) counter++; // конец файла = конец строки.
          }
         }
        catch (UnauthorizedAccessException)
        {
        }
      }
      Console.WriteLine("There were {0} lines.", counter);    
    }
  }
}