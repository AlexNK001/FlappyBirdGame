using System;

[Serializable]
public struct WallSpawnConfig
{
    public float MinDistance;
    public float MaxDistance;
    public int FullHeightWalls;
    public int MinUpperSize;
    public int MaxUpperSize;
    public int MinLowerSize;
    public int MaxLowerSize;
}