
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;

namespace CardGame
{
    class Program
    {
        static int turns;
        static int turns2;
        static List<Player> players = new List<Player>();
        static List<Player> playersTwo = new List<Player>();
        static List<Card> cards = new List<Card>();

        static void Main(string[] args)
        {
            cards = FillDeck();
            players = FillPlayers();
            playersTwo = FillPlayers();

            ShowMenu();
        }

        static void ShowMenu()
        {
            WriteLine("====================================");
            WriteLine("Card Game");
            WriteLine("====================================");
            WriteLine();
            string choice = null;
            while (choice != "0")
            {
                WriteLine();
                WriteLine("Choose Option:");
                WriteLine("\t 1) Async with await");
                WriteLine("\t 2) Async with Result");
                WriteLine("\t 3) Async with await and Result at the same time");
                WriteLine("\t 4) Synchronous Call for both async games");
                WriteLine("\t 0) Exit");
                choice = ReadLine();
                if (choice == "1")
                {

                    WriteLine("Beginning task \"Async with await\"");
                    Task.Run(() => PlayerGameAsync()).Wait();

                    try
                    {
                        Player winner = null;
                        foreach (var player in players)
                        {
                            if (player.CurrentCard == 13)
                            {
                                winner = player;
                            }
                        }
                        WriteLine($"Player {winner.ID} has won in {turns} turns!");
                    }
                    catch (NullReferenceException e)
                    {
                        WriteLine(e);
                    }
                }
                else if (choice == "2")
                {
                    WriteLine("Beginning task \"Async with Result\"");
                    Task.Run(() => PlayerGameTwoAsync()).Wait();
                    try
                    {
                        Player winner = null;
                        foreach (var player in playersTwo)
                        {
                            if (player.CurrentCard == 13)
                            {
                                winner = player;
                            }
                        }
                        WriteLine($"Player {winner.ID} has won in {turns2} turns!");
                    }
                    catch (NullReferenceException e)
                    {
                        WriteLine(e);
                    }
                }
                else if (choice == "3")
                {
                    Task.Run(() => DualGameAsync()).Wait();
                    WriteLine($"{turns} - {turns2}");
                }
                else if (choice == "4")
                {
                    DualGame();
                    WriteLine($"{turns} - {turns2}");
                }
                else { WriteLine("Choice incorrect"); }
            }
        }

        static void DualGame()
        {
            Task t1 = PlayerGameAsync();
            Task t2 = PlayerGameTwoAsync();
        }

        async static Task DualGameAsync()
        {
            WriteLine("Beginning task \"Async with await\"");
            Task t1 = PlayerGameAsync();
            WriteLine("Beginning task \"Async with Result\"");
            Task t2 = PlayerGameTwoAsync();
            await Task.WhenAll(t1, t2);
        }

        async static Task PlayerGameAsync()
        {
            foreach (Player player in players)
            {
                player.CurrentCard = 0;
            }
            turns = 0;

            while (players[0].CurrentCard < 13 &&
                    players[1].CurrentCard < 13 &&
                    players[2].CurrentCard < 13 &&
                    players[3].CurrentCard < 13)
            {
                await PlayerTurnAsync();
                turns++;
            }
            WriteLine("Ending task \"Async with await\"");
        }

        async static Task PlayerTurnAsync()
        {
            Task t1 = DrawCard(players[0]);
            Task t2 = DrawCard(players[1]);
            Task t3 = DrawCard(players[2]);
            Task t4 = DrawCard(players[3]);
            await Task.WhenAll(t1, t2, t3, t4);
            WriteLine($"1. - {players[0]} - {players[0].CurrentCard,2} || {players[1]} - {players[1].CurrentCard,2} || {players[2]} - {players[2].CurrentCard,2} || {players[3]} - {players[3].CurrentCard,2}");
        }

        static Task DrawCard(Player player)
        {
            Thread.Sleep(5);
            return Task.Run(() => {
                Random gen = new Random();
                int t = gen.Next(player.CurrentCard, 14);
                if (t == player.CurrentCard + 1)
                {
                        player.CurrentCard++;
                }
            });
        }

        async static Task PlayerGameTwoAsync()
        {
            foreach (Player player in playersTwo)
            {
                player.CurrentCard = 0;
            }
            turns2 = 0;

            while (playersTwo[0].CurrentCard < 13 &&
                    playersTwo[1].CurrentCard < 13 &&
                    playersTwo[2].CurrentCard < 13 &&
                    playersTwo[3].CurrentCard < 13)
            {
                await PlayerTurnTwoAsync();
                turns2++;
            }
            WriteLine("Ending task \"Async with Result\"");
        }

        async static Task PlayerTurnTwoAsync()
        {
            int t1 = DrawCardTwo(playersTwo[0]).Result;
            int t2 = DrawCardTwo(playersTwo[1]).Result;
            int t3 = DrawCardTwo(playersTwo[2]).Result;
            int t4 = DrawCardTwo(playersTwo[3]).Result;
            WriteLine($"2. - {playersTwo[0]} - {t1,2} || {playersTwo[1]} - {t2,2} || {playersTwo[2]} - {t3,2} || {playersTwo[3]} - {t4,2}");
        }

        static Task<int> DrawCardTwo(Player player)
        {
            Thread.Sleep(5);
            return Task<int>.Run(() => {
                Random gen = new Random();
                int t = gen.Next(player.CurrentCard, 14);
                if (t == player.CurrentCard + 1)
                {
                    player.CurrentCard++;
                }
                return player.CurrentCard;
            });
        }

        public static List<Card> FillDeck()
        {
            List<Card> result = new List<Card>();
                for (int i = 1; i < 14; i++)
                {
                    result.Add(new Card(i));
                }
            return result;
        }

        public static List<Player> FillPlayers()
        {
            List<Player> result = new List<Player>();
            for (int i = 1; i < 5; i++)
            {
                result.Add(new Player(i));
            }
            return result;
        }
    }
}
