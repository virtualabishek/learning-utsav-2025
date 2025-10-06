public abstract class AbstractPlayer
{
    public string Name { get; set; }
    public int CurrentBid { get; protected set; }
    public int TricksWon { get; set; }
    //Constructor: Protected (
    protected AbstractPlayer(string name)
    {
        Name = name;
    }
    // abstract method: Forces override
    public abstract void MakeBid();
    // Virtual Method: Can override for custom scoring.
    public virtual double CalculateRoundScore()
    {
        if (TricksWon >= CurrentBid)
            return CurrentBid + (TricksWon - CurrentBid) * 0.1;
        return -CurrentBid;
    }
    // Methods: resets round data
    public void ResetRound()
    {
        CurrentBid = 0;
        TricksWon = 0;
    }
    //  OVERRIDE, caustom ToString for player info.
    public override string ToString()
    {
        return $"{Name} (Bid: {CurrentBid}, Tricks Won: {TricksWon})";
    }
}
