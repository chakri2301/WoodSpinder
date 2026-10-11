using System;
using UnityEngine;

public class SlipperyTileSpawner:BaseSpawner
{
    //public GameObject[] prefabArray;
    override public void SpawnBlock(string data, Transform parent)
    {
        GameObject block = Instantiate(prefabArray[0]);
        block.transform.SetParent(parent);
        SlipperyTileData slipperyTileData = JsonUtility.FromJson<SlipperyTileData>(data);
        block.transform.position = new Vector3(slipperyTileData.X,slipperyTileData.Y,0);
        block.transform.localScale *= slipperyTileData.S;
        if (block.TryGetComponent(out SlipperyWoodScript sws))
        {
            print(slipperyTileData.coverAngle);
            sws.SetAngle(slipperyTileData.coverAngle, slipperyTileData.startAngle);
        }
        base.SpawnBlock(data, parent);
    }
}
[Serializable]
public class SlipperyTileData :TileData{
    public int coverAngle;
}
