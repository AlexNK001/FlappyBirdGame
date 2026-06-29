using System;
using UnityEngine;

[Serializable]
public class WallSpawnConfig
{
    [Header("Wall Parts")]
    [SerializeField, Min(1)] private int _minLowerPipeHeight = 1;
    [SerializeField, Min(2)] private int _minGapHeight = 2;
    [SerializeField, Min(1)] private int _minUpperPipeHeight = 1;
    [SerializeField] private int _totalWallHeight = 10;

    [Header("Spawn Distance")]
    [SerializeField, Min(0f)] private float _baseDistance = 10f;
    [SerializeField, Min(0f)] private float _minDistance = 2f;

    public int MinLowerPipeHeight => _minLowerPipeHeight;
    public int MinGapHeight => _minGapHeight;
    public int MinUpperPipeHeight => _minUpperPipeHeight;
    public int TotalWallHeight => _totalWallHeight;
    public float BaseDistance => _baseDistance;
    public float MinDistance => _minDistance;
}