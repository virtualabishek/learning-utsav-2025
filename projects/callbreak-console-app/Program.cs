class Program
{
    static void Main(string[] args)
    {
        try
        {
            // sabai player ko name full fill garna lai
            List<Player> players = new List<Player>();
            Console.WriteLine("Enter 4 player names (e.g Ram, Shyam, Hari):");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Player {i + 1}: ");
                string name = Console.ReadLine();
                players.Add(new Player(name));
            }
            GenericScore<double> totalScores = new GenericScore<double>();
            string[] roundNames = new string[5] { "Round1", "Round2", "Round3", "Round4", "Final" };
            string log = "Game Log:\n";
            Console.Write("Who starts? Enter name (e.g., A): ");
            string starterName = Console.ReadLine();
            int starterIndex = players.FindIndex(p => p.Name.Equals(starterName, StringComparison.OrdinalIgnoreCase));
            if (starterIndex == -1) throw new ArgumentException("Invalid starter name");

            Game game = new Game(players);
            for (int i = 0; i < roundNames.Length; i++)
            {
                Console.WriteLine($"\n{roundNames[i]}:");

                game.StartRound(starterIndex);  

                Console.WriteLine("\nRound Scores:");
                for (int p = 0; p < 4; p++)
                {
                    Player player = game[p];
                    double roundScore = player.CalculateRoundScore();
                    totalScores.AddScore(player.Name, roundScore);
                    Console.WriteLine($"{player.Name}: Bid {player.CurrentBid}, Won {player.TricksWon}, Score {roundScore}");
                    log += $"{roundNames[i]} - {player.Name}: {roundScore}\n";
                    player.ResetRound();
                }

                Console.WriteLine("\nCumulative Scores:");
                foreach (var kvp in totalScores.Scores)
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            File.WriteAllText("game_log.txt", log);
            Console.WriteLine("\nLog saved. Winner: " + totalScores.GetWinner());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}