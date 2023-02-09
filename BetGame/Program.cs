internal class Program
{
    private static void Main(string[] args)
    {
        Player player = new Player() { cash = 100, name = "The player" };
        Random random = new Random();

        while (true)
        {
            double odds = 0.75;
            player.WriteMyInfo();
            Console.Write("How much do you want to bet: ");
            string bet = Console.ReadLine();
            if (bet == "") return;
            if (int.TryParse(bet, out int amount))
            {

                int pot = player.ToPot(amount) * 2;
                double theMan = random.NextDouble();
                if (theMan > odds)
                {
                    player.WinPot(pot);
                    Console.WriteLine("You are one lucky dude");
                }
                else
                {
                    Console.WriteLine("That money is mine now, let's play again");
                }
            }
            else
            {
                Console.WriteLine("Please enter an amount (or a blank line to exit).");
            }
        }
        
    }
}

class Player
{
    public string name;
    public int cash;
    // writes name and cash amounts
    public void WriteMyInfo()
    {
        Console.WriteLine(name + " has $" + cash);
    }
    // removing amount of cash from wallet
    public int ToPot(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Dealer says: $" + amount + " isn't a valid amount");
            return 0;
        }
        if (amount > cash)
        {
            Console.WriteLine("Dealer says: you don't have $" + amount + " in cash");
            return 0;
        }
        cash -= amount;
        return amount;
    }
    // adding amount of cash to wallet
    public void WinPot(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("I don't know how we got here");
        }
        else
        {
            cash += amount;
        }
    }
}