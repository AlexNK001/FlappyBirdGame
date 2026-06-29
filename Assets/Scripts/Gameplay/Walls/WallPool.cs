using UnityEngine;
using UnityEngine.Pool;

public class WallPool : MonoBehaviour
{
    [SerializeField] private Wall _prefab;
    private ObjectPool<Wall> _pool;

    private void Awake()
    {
        _pool = new(OnCreate, OnGet, OnRelease, OnDestroyWall);
    }

    public Wall Get() => _pool.Get();

    public void Release(Wall wall) => _pool.Release(wall);

    private Wall OnCreate()
    {
        Wall wall = Instantiate(_prefab);
        wall.gameObject.SetActive(false);
        return wall;
    }

    private void OnGet(Wall wall) => wall.gameObject.SetActive(true);
    
    private void OnRelease(Wall wall) => wall.gameObject.SetActive(false);
    
    private void OnDestroyWall(Wall wall) => Destroy(wall.gameObject);
}