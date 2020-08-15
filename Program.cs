using System;

namespace BlackjackCS
{

    class Card
    {
        public string Name { get; set; }

        public int CardValue(string Name)
        {
            if (Name.Contains("Ace"))
            {
                return 11;

            }
            else if (Name.Contains("2"))
            {
                return 2;

            }
            else if (Name.Contains("3"))
            {
                return 3;

            }
            else if (Name.Contains("4"))
            {
                return 4;

            }
            else if (Name.Contains("5"))
            {
                return 5;

            }
            else if (Name.Contains("6"))
            {
                return 6;

            }
            else if (Name.Contains("7"))
            {
                return 7;

            }
            else if (Name.Contains("8"))
            {
                return 8;

            }
            else if (Name.Contains("9"))
            {
                return 9;

            }

            else
            {
                return 10;
            }

        }
    }













    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C#");
        }
    }
}
