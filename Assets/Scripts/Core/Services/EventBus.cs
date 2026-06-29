public class EventBus
{
    public EventElement<int> ScoreChanged { get; } = new();
    public EventElement<int> BestScoreChanged { get; } = new();
    public EventElement PauseToggled { get; } = new();
    public EventElement JumpRequested { get; } = new();
    //public EventElement PausaPressed { get; } = new();
    public EventElement Restarted { get; } = new();
    public EventElement Paused { get; } = new();
    public EventElement Resumed { get; } = new();
}