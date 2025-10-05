public class GenericScore<T> where T : struct
{
    public Dictionary<string, T> Scores { get; } = new Dictionary<string, T>();
    public void AddScore(string player, T score)
    {
        if (Scores.ContainsKey(player))
            Scores[player] = (T)(object)((dynamic)Scores[player] + (dynamic)score);
        else
            Scores[player] = score;
    }
    public string GetWinner()
    {
        return Scores.OrderByDescending(kvp => kvp.Value).First().Key;
    }
}