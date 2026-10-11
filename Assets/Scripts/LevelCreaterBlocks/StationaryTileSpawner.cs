using System;
using UnityEngine;

public class StationaryTileSpawner : BaseSpawner
{
    public override void SpawnBlock(string data, Transform parent)
    {
        GameObject block = Instantiate(prefabArray[0]);
        block.transform.SetParent(parent);
        StationaryTileData stationaryTileData = JsonUtility.FromJson<StationaryTileData>(data);
        block.transform.position = new Vector3(stationaryTileData.X,stationaryTileData.Y,0);
        block.transform.localScale *= stationaryTileData.S;
        if (block.TryGetComponent(out StationaryWoodScript sws))
        {
            sws.SetSpeed(stationaryTileData.rotateSpeed);
        }
        base.SpawnBlock(data, parent);
    }
}
[Serializable]
public class StationaryTileData :TileData{
    public int rotateSpeed;
}