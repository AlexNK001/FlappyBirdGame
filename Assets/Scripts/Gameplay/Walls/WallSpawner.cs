using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WallSpawner : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _speed;
    [SerializeField] private WallPool _pool;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _despawnXValue;

    private WallRandomizer _wallRandomizer;
    private EventBus _bus;
    private readonly List<Wall> _activeWalls = new();
    private float _distanceToNextSpawn;

    [Inject]
    private void Construct(EventBus bus, WallRandomizer wallRandomizer)
    {
        _bus = bus;
        _wallRandomizer = wallRandomizer;

        _bus.Restarted.Invoked += OnRestart;
    }

    private void OnDestroy()
    {
        _bus.Restarted.Invoked -= OnRestart;
    }

    private void Update()
    {
        TrySpawnWall();
        MoveWalls();
        DespawnPassedWalls();
    }

    private void OnRestart()
    {
        ClearAllWalls();
    }

    private void TrySpawnWall()
    {
        if (_distanceToNextSpawn >= 0f)
            return;

        Wall wall = SpawnWall();
        _wallRandomizer.Randomize(wall, out float distance);
        _distanceToNextSpawn = distance;
    }

    private Wall SpawnWall()
    {
        Wall wall = _pool.Get();
        wall.transform.position = _spawnPosition.position;
        _activeWalls.Add(wall);
        return wall;
    }

    private void MoveWalls()
    {
        Vector2 movement = _speed * Time.deltaTime * Vector2.left;
        _distanceToNextSpawn -= Mathf.Abs(movement.x);

        foreach (var wall in _activeWalls)
        {
            wall.transform.Translate(movement, Space.Self);
        }
    }

    private void DespawnPassedWalls()
    {
        for (int i = _activeWalls.Count - 1; i >= 0; i--)
        {
            if (_activeWalls[i].transform.position.x < _despawnXValue)
            {
                DespawnWallAt(i);
            }
        }
    }

    private void DespawnWallAt(int index)
    {
        _pool.Release(_activeWalls[index]);
        _activeWalls.RemoveAt(index);
    }

    private void ClearAllWalls()
    {
        for (int i = _activeWalls.Count - 1; i >= 0; i--)
        {
            _pool.Release(_activeWalls[i]);
        }

        _activeWalls.Clear();
    }
}