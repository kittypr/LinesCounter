using System;

namespace NumberGuesser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            string[] abuses = { ", I bet you JavaScript user . . .", ", is it legal to be as stuped as you are????",
                ", oh God, you better play something easier.", ", you know, this program cheks your IQ, and I ahve baaaad news . . .",
                ", at least, you tried.", ", are you sure you are human? I think you are dog at best. Good boy, try again.",
                ", even I've tired already!!!", ", did you understand the rules?", ", hint: it's a number between 0 and 100 :3",
                ", I wish something else lasts that long . . ."
            };
            int[] history = new int[101]; // зачем нам 1000 элементов, ведь всего 100 чисел?
            Console.WriteLine("Hello, I'm Glados the Robot! Lets guess some numbers! Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Hope you are lucky one or it's gonna hurt you, " + name + ".");
            Console.WriteLine("Lets play, there is a number in range 0 - 100. If you win I'll reward you with a cake!");
            
            
            int puzzle = random.Next(101);
            int attempt = -1;
            int attemptNumber = 1;
            
            DateTime start = DateTime.Now;
            while (puzzle != attempt)
            {
                if (attemptNumber % 4 == 0) Console.WriteLine(name + abuses[random.Next(abuses.Length)]);
                string input = Console.ReadLine();
                if (input == "q")
                {
                    Console.WriteLine("Sorry (not sorry), bye!");
                    Environment.Exit(0);
                }
                if (Int32.TryParse(input, out attempt))
                {
                    if (attempt > puzzle)
                    {
                        Console.WriteLine("bigger then puzzle");
                        history[attemptNumber] = attempt;
                        attemptNumber++;
                    }
                    if (attempt < puzzle)
                    {
                        Console.WriteLine("less then puzzle");
                        history[attemptNumber] = attempt;
                        attemptNumber++;
                    }

                    if (attempt == puzzle)
                    {
                        attemptNumber++;
                    }
                }
                else
                {
                    Console.WriteLine("Are you kidding me? Don't you know what is number?");
                }
            }
            attemptNumber--;
            DateTime finish = DateTime.Now;
            TimeSpan totalTime = finish - start;
            Console.WriteLine("AT LAST! I thought it never ends!");
            Console.WriteLine("You required for " + attemptNumber + " attempts and " + totalTime.Seconds + 
                              " seconds to guess simple number, shame on you!");
            Console.WriteLine("Your pathetic attempts:");
            for (int i = 1; i <= attemptNumber-1; i++)
            {
                string comparison = history[i] < puzzle ? "less then puzzle" : "bigger then puzzle";
                Console.WriteLine("Attempt #{0}: {1} - {2}", i, history[i], comparison);
            }
            Console.WriteLine("And puzze is: " + puzzle); 
            Console.WriteLine("Bye! Hope I'll never see you again!");        
        }
    }
}