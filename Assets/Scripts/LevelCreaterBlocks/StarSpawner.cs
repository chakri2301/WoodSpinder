using UnityEngine;

public class StarSpawner:BaseSpawner
{
    override public void SpawnBlock(string data, Transform parent)
    {
        BasicBlockData tileData  =  JsonUtility.FromJson<BasicBlockData>(data);
        GameObject block = Instantiate(prefabArray[0]);
        block.transform.position = new Vector3(tileData.X, tileData.Y, 0);
        block.transform.localScale *= tileData.S;
        block.transform.SetParent(parent);
        base.SpawnBlock(data, parent);
    }
}