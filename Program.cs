class Program
{
    public static void Main(string[] args)
    {
        ChoclateDispenser choclateDispenser = new ChoclateDispenser();

        choclateDispenser.AddChocolates("green", 10);
        choclateDispenser.AddChocolates("silver", 20);
        choclateDispenser.AddChocolates("blue", 30);

        int[] chocs = choclateDispenser.NoOfChocolates();
        for(int i = 0;  i < chocs.Length; i++)
        {
            Console.WriteLine(chocs[i]);
        }
    }
}