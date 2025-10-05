public interface IBiddable
{
    void Bid(int value);
    event Action<string> OnBidPlaced;
}


public class Player : AbstractPlayer
{
    public Player(string name) : base(name) { }

    public override void MakeBid()
    {
        Console.Write($"{Name}, enter your bid (1-13): ");
        CurrentBid = int.Parse(Console.ReadLine());
    }
}