using UnityEngine;

public abstract class BaseSpawner:MonoBehaviour
{
    public const float multiplier = 0.2f;
    public GameObject[] prefabArray;
    virtual public void SpawnBlock(string data, Transform parent)
    {
//        Debug.Log("SPawned a block");
    }
}
