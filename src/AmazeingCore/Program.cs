using System;
using System.Linq;
using System.Threading.Tasks;

namespace AmazeingCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
			var httpClient = new System.Net.Http.HttpClient();
			httpClient.DefaultRequestHeaders.Add("Authorization", "<your key>");
			
			var client = new AmazeingClient("https://maze.hightechict.nl/", httpClient);

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
            Console.WriteLine($"Making a move");
            var newPossibles = await client.Move(enterResult.PossibleMoveActions.First().Direction);
            Console.WriteLine(string.Join(", ", newPossibles.PossibleMoveActions.Select( ma => ma.Direction)));

            Console.ReadLine();
        }
    }
}
