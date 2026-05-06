using UnityEngine;
using UnityEngine.Pool;

public class WallPool : MonoBehaviour
{
    [SerializeField] private Wall _prefab;
    
    private ObjectPool<Wall> _wallPool;
    
    private void Awake()
    {
        _wallPool = new
            (
                Create,
                (pair) => pair.gameObject.SetActive(true), 
                (pair) => pair.gameObject.SetActive(false), 
                (pair) => Destroy(pair.gameObject)
                );
    }

    private Wall Create()
    {
        var pair = Instantiate(_prefab);
        pair.gameObject.SetActive(false);
        return pair;
    }

    public Wall Get()
    {
        return _wallPool.Get();
    }

    public void Reliase(Wall wall)
    {
        _wallPool.Release(wall);
    }
}