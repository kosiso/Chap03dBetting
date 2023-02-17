using static System.Console;

namespace Chap03dBetting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random random = new();
            double odds = 0.75;
            Bettor player = new() { Name = "Kelvin", Cash = 100 };

            WriteLine($"Welcome {player.Name} to the House. Today's odds is {odds}\n");

            while (true)
            {
                player.WriteMyInfo();
            placeBet:
                WriteLine($"How much money do you want to bet? If not betting, enter a blank line");
                string? howMuchBetted = ReadLine();
                if (string.IsNullOrEmpty(howMuchBetted))
                {
                    return;
                }

                if (int.TryParse(howMuchBetted, out int amount))
                {
                    if (amount > player.Cash)
                    {
                        WriteLine($"Your cash is {player.Cash}. You don't have enough cash to place this bet\n");
                        goto placeBet;
                    }
                    if (amount <= 0)
                    {
                        WriteLine("Enter a valid amount!\n");
                        goto placeBet;
                    }
                    int pot = player.GiveCash(amount) * 2;
                    if (random.NextDouble() > odds)
                    {
                        player.ReceiveCash(pot);
                        WriteLine($"Bet won! You have won {pot} Naira.\n");
                    }
                    else
                    {
                        WriteLine("You lost your bet!\n");
                        if (player.Cash == 0)
                        {
                            WriteLine($"You don't have anymore cash to place bet: Available cash = {player.Cash}.");
                            return;
                        }
                    }
                }
                else
                {
                    WriteLine($"Enter a valid amount!\n");
                    goto placeBet;
                }
            }
        }
    }
}