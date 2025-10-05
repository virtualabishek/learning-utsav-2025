public partial class Game
{
    private List<Player> _players;
    public Player this[int index]
    {
        get => _players[index];
    }

    public Game(List<Player> players)
    {
        _players = players;
    }

    public void StartRound(int starterIndex)
    {
        string bidLog = "Bid (rotation from " + _players[starterIndex].Name + "):\n";
        for (int i = 0; i < 4; i++)
        {
            int playerIdx = (starterIndex + i) % 4;
            _players[playerIdx].MakeBid();
            bidLog += $"{_players[playerIdx].Name}: {_players[playerIdx].CurrentBid}\n";
        }
        Console.WriteLine(bidLog);
        int totalTricks = 0;
        while (totalTricks != 13)
        {
            try
            {
                totalTricks = 0;
                for (int i = 0; i < 4; i++)
                {
                    int playerIdx = (starterIndex + i) % 4;
                    Console.WriteLine($"{_players[playerIdx].Name}, tricks won (0-13): ");
                    _players[playerIdx].TricksWon = int.Parse(Console.ReadLine());
                    totalTricks += _players[playerIdx].TricksWon;

                }
                if (totalTricks != 13) throw new InvalidOperationException("Must sum to 13!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid: {ex.Message}. Retry.");
            }
        }
    }



}

