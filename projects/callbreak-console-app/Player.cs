// interface defination, contract for biding

public interface IBiddable
{
    // method to implement to set the bid
    void Bid(int value);
    // event used the delegant action. delegate for the notifications.
    event Action<string> OnBidPlaced;
}

// class just inheriting from the abstract player
public class Player : AbstractPlayer
{
    // constructors
    public Player(string name) : base(name) { }
    // override abstract method for abstractPlayer(Polymorphism)
    public override void MakeBid()
    {
        Console.Write($"{Name}, enter your bid (1-13): ");
        CurrentBid = int.Parse(Console.ReadLine());
    }
}