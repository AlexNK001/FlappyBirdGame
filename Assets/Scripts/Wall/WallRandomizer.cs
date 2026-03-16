using UnityEngine;

public class WallRandomizer
{
    public void Randomize(Wall wall)
    {
        int upperSize = Random.Range(3, 5);
        int scoringSize = Random.Range(3, 5);
        int lowerSize = 10 - upperSize - scoringSize;
        wall.SetColliderSize(upperSize, scoringSize, lowerSize);
    }

    public float GetRandomDistance()
    {
        return Random.Range(3f, 5f);
    }
}