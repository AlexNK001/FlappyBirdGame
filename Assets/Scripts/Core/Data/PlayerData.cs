public class PlayerData
{
    public bool IsAlive { get; private set; } = true;

    public void Revive()
    {
        IsAlive = true;
    }

    public void Kill()
    {
        IsAlive = false;
    }
}