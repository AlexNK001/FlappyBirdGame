public class ScoreData 
{
    public ScoreData(int best)
    {
        Best = best;
    }

    public int Current { get; private set; }
    public int Best { get; private set; }
    
    public void Add()
    {
        Current++;
    }

    public void Reset()
    {
        Current = 0;
    }

    public bool TryUpdateBestScore()
    {
        bool increased = Current > Best;
        
        if (increased)
        {
            Best = Current;
        }

        return increased;
    }
}