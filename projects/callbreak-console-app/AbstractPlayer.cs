public abstract class AbstractPlayer
{
    public string Name { get; set; }
    public int CurrentBid { get; protected set; }
    public int TricksWon { get; set; }

    protected AbstractPlayer(string name)
    {
        Name = name;
    }

    public abstract void MakeBid();

    public virtual double CalculateRoundScore()
    {
        if (TricksWon >= CurrentBid)
            return CurrentBid + (TricksWon - CurrentBid) * 0.1;
        return -CurrentBid;
    }

    public void ResetRound()
    {
        CurrentBid = 0;
        TricksWon = 0;
    }

    public override string ToString()
    {
        return $"{Name} (Bid: {CurrentBid}, Tricks Won: {TricksWon})";
    }
}
