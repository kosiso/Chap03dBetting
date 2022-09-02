using static System.Console;

namespace Chap03dBetting
{
    /// <summary>
    /// Calculate and transfer a specified amount between to Guy objects
    /// </summary>
    internal class Guy
    {
        public string? Name { get; set; }
        public int Cash { get; set; }

        /// <summary>
        /// Write the name and amount of cash of each Guy object
        /// </summary>
        public void WriteMyInfo()
        {
            WriteLine($"{Name} has {Cash} Naira.");
        }

        /// <summary>
        /// Give a specified amount to the other Guy object
        /// </summary>
        /// <param name="amount">Amount to be given</param>
        /// <returns>Amount given</returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                WriteLine($"{Name} says: {amount} isn't a valid amount.");
                return 0;
            }
            if (amount > Cash)
            {
                WriteLine($"{Name} says: I don't have enough cash to give you {amount} Naira.");
                return 0;
            }
            Cash -= amount;
            return amount;
        }

        /// <summary>
        /// Receive a specified amount from the other Guy object
        /// </summary>
        /// <param name="amount">Amount received</param>
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                WriteLine($"{Name} says: This isn't a valid amount I'll take!)");
            }
            else
            {
                Cash += amount;
            }
        }
    }
}
