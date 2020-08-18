
using System;
using System.Collections.Generic;
using System.Linq;
namespace Blackjack
{
    class Hand
    {

        public List<Card> Cards = new List<Card>();

        public int TotalValue()
        {
            var total = 0;
            foreach (var card in Cards)
            {
                total = total + card.Value();
            }
            return total;
        }

        public void AddCardToHand(Card cardToAdd)
        {

            Cards.Add(cardToAdd);
        }
    }
    class Card
    {

        public string Face { get; set; }

        public string Suit { get; set; }

        public int Value()
        {
            var answer = 0;
            switch (Face)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                    answer = int.Parse(Face);
                    break;
                case "J":
                case "Q":
                case "K":
                    answer = 10;
                    break;
                case "A":
                    answer = 11;
                    break;
            }
            return answer;
        }
    }
    class Program
    {

        static void Greeting()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==========Welcome to my prototype Mo's Blackjack Game==========");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();




        }


        static void Main(string[] args)
        {


            Greeting();



            var deck = new List<Card>();

            var suits = new List<string>() { "Club", "Diamond", "Heart", "Spade" };

            var faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (var suit in suits)
            {

                foreach (var face in faces)

                {

                    var ourCard = new Card()
                    {
                        Face = face,
                        Suit = suit,
                    };

                    deck.Add(ourCard);
                }
            }

            var n = deck.Count();

            for (var rightIndex = n - 1; rightIndex >= 1; rightIndex--)
            {
                var randomNumberGenerator = new Random();

                var leftIndex = randomNumberGenerator.Next(rightIndex);

                var leftCard = deck[rightIndex];

                var rightCard = deck[leftIndex];

                deck[rightIndex] = rightCard;

                deck[leftIndex] = leftCard;
            }

            var player = new Hand();

            var dealer = new Hand();

            var firstCardForPlayer = deck[0];

            deck.Remove(firstCardForPlayer);

            player.AddCardToHand(firstCardForPlayer);

            var secondCardForPlayer = deck[0];
            deck.Remove(secondCardForPlayer);
            player.AddCardToHand(secondCardForPlayer);

            var firstCardForDealer = deck[0];
            deck.Remove(firstCardForDealer);
            dealer.AddCardToHand(firstCardForDealer);

            var secondCardForDealer = deck[0];
            deck.Remove(secondCardForDealer);
            dealer.AddCardToHand(secondCardForDealer);

            var choice = "";
            while (choice != "STAND" && player.TotalValue() <= 21)
            {

                foreach (var card in player.Cards)
                {

                    Console.WriteLine($"The {card.Face} of {card.Suit}");
                }

                Console.WriteLine($"The total is: {player.TotalValue()}");

                Console.Write("HIT or STAND? ");
                choice = Console.ReadLine();

                if (choice == "HIT")
                {
                    var additionalCard = deck[0];
                    deck.Remove(additionalCard);
                    player.AddCardToHand(additionalCard);
                }

            }

            foreach (var card in player.Cards)
            {

                Console.WriteLine($"The {card.Face} of {card.Suit}");
            }

            Console.WriteLine($"The player's total is: {player.TotalValue()}");




            while (player.TotalValue() <= 21 && dealer.TotalValue() < 17)
            {

                var additionalCard = deck[0];
                deck.Remove(additionalCard);
                dealer.AddCardToHand(additionalCard);
            }

            foreach (var card in dealer.Cards)
            {

                Console.WriteLine($"The {card.Face} of {card.Suit}");
            }

            Console.WriteLine($"The dealer total is: {dealer.TotalValue()}");

            if (player.TotalValue() > 21)
            {
                Console.WriteLine("Dealer wins!");
            }
            else
            {

                if (dealer.TotalValue() > 21)
                {
                    Console.WriteLine("Player wins");
                }
                else
                {

                    if (dealer.TotalValue() > player.TotalValue())
                    {
                        Console.WriteLine("Dealer Wins!");
                    }
                    else
                    {
                        if (player.TotalValue() > dealer.TotalValue())
                        {
                            Console.WriteLine("Player wins");
                        }
                        else
                        {
                            Console.WriteLine("Tie goes to the dealer");

                        }
                    }
                }
            }
        }
    }
}
