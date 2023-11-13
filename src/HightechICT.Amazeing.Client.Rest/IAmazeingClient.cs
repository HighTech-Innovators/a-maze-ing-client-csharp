namespace HightechICT.Amazeing.Client.Rest;

public interface IAmazeingClient
{
    Task ForgetPlayer();
    Task RegisterPlayer(string name);
    Task<ICollection<MazeInfo>> AllMazes();
    Task<PossibleActionsAndCurrentScore> EnterMaze(string mazeName);
    Task<PossibleActionsAndCurrentScore> Move(Direction direction);
    Task<PossibleActionsAndCurrentScore> CollectScore();
    Task ExitMaze();
    Task<PossibleActionsAndCurrentScore> Tag(long tag);
    Task<PossibleActionsAndCurrentScore> PossibleActions();
    Task<PlayerInfo> GetPlayerInfo();
}