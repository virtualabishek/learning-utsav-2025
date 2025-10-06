// class defination : custom exception for invalid bids
public class InvalidBidException : Exception
{
    public InvalidBidException(string msg) : base(msg) { }
}