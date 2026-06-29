public class GameSessionData 
{
    public bool IsPlaying { get; private set; }
    
    public void Pause()
    {
        IsPlaying = false;
    }

    public void Resume()
    {
        IsPlaying = true;
    }
}