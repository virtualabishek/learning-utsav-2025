// this class just stores the players score in dictionary
public class GenericScore<T> where T : struct
{
    // property, public read-only dictionary to hold scores.
    public Dictionary<string, T> Scores { get; } = new Dictionary<string, T>();
    // methods that adds or updates a players score.
    public void AddScore(string player, T score)
    {
        if (Scores.ContainsKey(player))
            Scores[player] = (T)(object)((dynamic)Scores[player] + (dynamic)score);
        else
            Scores[player] = score;
    }
    // methods to find the winner
    public string GetWinner()
    {
        return Scores.OrderByDescending(kvp => kvp.Value).First().Key;
    }
}