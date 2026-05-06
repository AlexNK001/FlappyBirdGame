using UnityEngine;

public class WallRandomizer
{
    private readonly WallSpawnConfig _config;

    public WallRandomizer(WallSpawnConfig config)
    {
        _config = config;
    }

    public void Randomize(Wall wall)
    {
        int upperSize = Random.Range(_config.MinUpperSize, _config.MaxUpperSize);
        int scoringSize = Random.Range(_config.MinLowerSize, _config.MaxLowerSize);
        int lowerSize = _config.FullHeightWalls - upperSize - scoringSize;
        wall.SetColliderHeight(upperSize, scoringSize, lowerSize);
    }

    public float GetRandomDistance()
    {
        return Random.Range(_config.MinDistance, _config.MaxDistance);
    }
}