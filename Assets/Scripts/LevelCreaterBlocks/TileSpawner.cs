using System;
using UnityEngine;

public class TileSpawner : BaseSpawner
{
    //override public GameObject[] prefabArray;
    public override void SpawnBlock(string data, Transform parent)
    {
        TileData tileData  =  JsonUtility.FromJson<TileData>(data);
        GameObject block = Instantiate(prefabArray[0]);
        block.transform.position = new Vector3(tileData.X, tileData.Y, 0);
        block.transform.localScale *= tileData.S;
        block.transform.SetParent(parent);
        base.SpawnBlock(data, parent);
    }
}
[Serializable]
public class TileData : BasicBlockData
{
    public int startAngle;
}