using System.Collections.Generic;
using UnityEngine;

public class WallHandler : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _speed;
    [SerializeField] private WallPool _pool;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _despawnXValue;

    private WallRandomizer _wallRandomizer;
    private List<Wall> _walls;
    private float _spawnDistance;

    private void Start()
    {
        _wallRandomizer = new WallRandomizer();
        _walls = new List<Wall>();
    }

    private void Update()
    {
        if (_spawnDistance < 0f)
        {
            Wall wall = AddWallToSpawnPosition();
            _wallRandomizer.Randomize(wall);
            _spawnDistance = _wallRandomizer.GetRandomDistance();
        }

        Vector2 moveDirection = _speed * Time.deltaTime * Vector2.left;
        _spawnDistance -= Mathf.Abs(moveDirection.x);

        for (int i = 0; i < _walls.Count; i++)
        {
            _walls[i].transform.Translate(moveDirection, Space.Self);

            if (_walls[i].transform.position.x < _despawnXValue)
            {
                RemoveWallByIndex(i);
            }
        }
    }

    public void Restart()
    {
        for (int i = _walls.Count - 1; i >= 0; i--)
        {
            RemoveWallByIndex(i);
        }

        _spawnDistance = _wallRandomizer.GetRandomDistance();
    }
    
    private Wall AddWallToSpawnPosition()
    {
        Wall wall = _pool.Get();
        wall.transform.position = _spawnPosition.position;
        _walls.Add(wall);
       
        return wall;
    }
    
    private void RemoveWallByIndex(int index)
    {
        _pool.Relise(_walls[index]);
        _walls.RemoveAt(index);
    }
}