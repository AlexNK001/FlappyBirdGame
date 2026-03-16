using UnityEngine;
using UnityEngine.Pool;

public class WallPool : MonoBehaviour
{
    [SerializeField] private Wall _prefab;
    
    private ObjectPool<Wall> _pipesPool;
    
    private void Start()
    {
        _pipesPool = new
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
        return _pipesPool.Get();
    }

    public void Relise(Wall pipe)
    {
        _pipesPool.Release(pipe);
    }
}