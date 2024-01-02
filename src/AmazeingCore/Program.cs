using System;
using System.Linq;
using System.Threading.Tasks;
using HightechICT.Amazeing.Client.Rest;

namespace AmazeingCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "HTI Thanks You [3KE]");

            IAmazeingClient client = new AmazeingClient(httpClient)
            {
                BaseUrl = "https://maze.hightechict.nl/",
            };

            // Forget player, in order to hard-reset if "I" (the player, by key) was still in a Maze
            await client.ForgetPlayer();
            Console.WriteLine("About to register...");
            await client.RegisterPlayer(name: "<your name here>");

            var allMazes = await client.AllMazes();

            foreach (var maze in allMazes)
                Console.WriteLine($"[{maze.Name}] has a potential reward of [{maze.PotentialReward}] and contains [{maze.TotalTiles}] tiles;");

            var chosenMaze = allMazes.First();
            Console.WriteLine($"Choosing maze {chosenMaze.Name}");

            var enterResult = await client.EnterMaze(chosenMaze.Name);
            Console.WriteLine(string.Join(", ", enterResult.PossibleMoveActions.Select( ma => ma.Direction)));

            Console.WriteLine("Tagging the entering tile");
            var moveOptions = await client.Tag(1);

            Console.WriteLine($"Making a move");
            var newMoveOptions = await client.Move(enterResult.PossibleMoveActions.First().Direction);
            Console.WriteLine(string.Join(", ", newMoveOptions.PossibleMoveActions.Select(ma => ma.Direction)));

            Console.ReadLine();
        }
    }
}
