class Program
{
    static void Main(string[] args)
    {
        try
        {
            // sabai player ko name full fill garna lai
            // collections list for dynamic players
            List<Player> players = new List<Player>(); // creates empty list
            Console.WriteLine("Enter 4 player names (e.g Ram, Shyam, Hari):");
            for (int i = 0; i < 4; i++) 
            {
                Console.Write($"Player {i + 1}: ");
                string name = Console.ReadLine();
                players.Add(new Player(name));
            }
            // generics: this is instance for double scores and creates score tracker
            GenericScore<double> totalScores = new GenericScore<double>();
            // array stores fixed round names
            string[] roundNames = new string[5] { "Round1", "Round2", "Round3", "Round4", "Final" };
            string log = "Game Log:\n";
            Console.Write("Who starts? Enter name (e.g., A): ");
            string starterName = Console.ReadLine();
            // FindIndex: searches list matching the name
            int starterIndex = players.FindIndex(p => p.Name.Equals(starterName, StringComparison.OrdinalIgnoreCase));
            if (starterIndex == -1) throw new ArgumentException("Invalid starter name");
            // game instance
            Game game = new Game(players); // passes the players list
            for (int i = 0; i < roundNames.Length; i++) //loop over rounds
            {
                Console.WriteLine($"\n{roundNames[i]}:");

                game.StartRound(starterIndex);  

                Console.WriteLine("\nRound Scores:");
                for (int p = 0; p < 4; p++)
                {
                    Player player = game[p]; //indexer access
                    double roundScore = player.CalculateRoundScore(); // this calls virtual methods
                    totalScores.AddScore(player.Name, roundScore); // update cumulative
                    Console.WriteLine($"{player.Name}: Bid {player.CurrentBid}, Won {player.TricksWon}, Score {roundScore}");
                    log += $"{roundNames[i]} - {player.Name}: {roundScore}\n"; // append to log string
                    player.ResetRound(); // reset for next round
                }

                Console.WriteLine("\nCumulative Scores:"); // header
                foreach (var kvp in totalScores.Scores) // for each in dict
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            // files IO : writes log string to the file

            File.WriteAllText("game_log.txt", log); 
            Console.WriteLine("\nLog saved. Winner: " + totalScores.GetWinner()); // calls winner methods
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}