using System;
using UnityEngine;

public class StationarySlipperyTileSpawner:BaseSpawner
{
    //public GameObject[] prefabArray;
    override public void SpawnBlock(string data, Transform parent)
    {
        GameObject block = Instantiate(prefabArray[0]);
        block.transform.SetParent(parent);
        StationarySlipperyTileData stationarySlipperyTileData = JsonUtility.FromJson<StationarySlipperyTileData>(data);
        block.transform.position = new Vector3(stationarySlipperyTileData.X,stationarySlipperyTileData.Y,0);
        block.transform.localScale *= stationarySlipperyTileData.S;
        if (block.TryGetComponent(out SlipperyStationaryScript sss))
        {
            //print(c);
            sss.SetAngle(stationarySlipperyTileData.coverAngle, stationarySlipperyTileData.startAngle);
            sss.setStartSpeed(stationarySlipperyTileData.rotateSpeed);
        }
        base.SpawnBlock(data, parent);
    }
}
[Serializable]
public class StationarySlipperyTileData:SlipperyTileData
{
    public int rotateSpeed;
}
