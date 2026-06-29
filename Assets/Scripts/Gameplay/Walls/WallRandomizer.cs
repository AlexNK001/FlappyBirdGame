using UnityEngine;

public class WallRandomizer
{
    private readonly WallSpawnConfig _config;

    public WallRandomizer(WallSpawnConfig config)
    {
        _config = config;
    }

    public void Randomize(Wall wall, out float distance)
    {
        int maxLowerHeight = _config.TotalWallHeight - _config.MinGapHeight - _config.MinUpperPipeHeight;
        int lowerHeight = Random.Range(_config.MinLowerPipeHeight, maxLowerHeight);

        int maxGapHeight = _config.TotalWallHeight - lowerHeight - _config.MinUpperPipeHeight;
        int gapHeight = Random.Range(_config.MinGapHeight, maxGapHeight);

        int upperHeight = _config.TotalWallHeight - lowerHeight - gapHeight;

        wall.SetColliderHeight(lowerHeight, gapHeight, upperHeight);
        distance = _config.BaseDistance - gapHeight;
    }

    public float GetDistance(int gapHeight)
    {
        float distance = _config.BaseDistance - gapHeight;

        return Mathf.Max(distance, _config.MinDistance);
    }
}