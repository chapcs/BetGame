internal class Program
{
    private static void Main(string[] args)
    {
        double odds = 0.75;
        Random random = new Random();
        Player player = new Player() { cash = 100, name = "The player" };

        Console.WriteLine("Welcome to Craps, roll a seven for double or nothing.\nOdds are set at " + odds);
        while (player.cash > 0)
        {
            player.WriteMyInfo();
            Console.Write("How much do you want to bet: ");
            string bet = Console.ReadLine();
            //if (bet == "") return;
            if (int.TryParse(bet, out int amount))
            {
                int pot = player.ToPot(amount) * 2;
                double theMan = random.NextDouble();
                if (pot > 0)
                {
                    Console.WriteLine("Rolling for 7 . . .");
                    Thread.Sleep(1500);
                    if (theMan > odds)
                    {
                        player.WinPot(pot);
                        Console.WriteLine("You are one lucky dude\n");
                    }
                    else
                    {
                        Console.WriteLine("You always lose, let's play again\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter an amount (or a blank line to exit).\n");
            }
        }
        Console.WriteLine("Would you like another Lotus Flower?");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }
}

class Player
{
    public string name;
    public int cash;
    public void WriteMyInfo()
    {
        Console.WriteLine(name + " has $" + cash);
    }
    public int ToPot(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Dealer says \"$" + amount + " isn't a valid amount\"\n");
            return 0;
        }
        if (amount > cash)
        {
            Console.WriteLine("Dealer says \"You don't have $" + amount + " in chips\"\n");
            return 0;
        }
        cash -= amount;
        return amount;
    }
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