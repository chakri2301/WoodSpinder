using System;
using UnityEngine;

public class BeeSpawner : BaseSpawner
{
    public override void SpawnBlock(string data, Transform parent)
    {
        GameObject block = Instantiate(prefabArray[0]);
        BeeData beeData = JsonUtility.FromJson<BeeData>(data);
        block.transform.position = new Vector3(beeData.X, beeData.Y, 0);
        block.transform.localScale *= beeData.S;
        if (block.TryGetComponent(out BeeScript bs))
        {
            float[] worldPos = { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                worldPos[i] = multiplier * beeData.pos[i];
            }
            bs.SetPos(worldPos, beeData.time);
        }
        base.SpawnBlock(data, parent);
    }
}
[Serializable]
public class BeeData : BasicBlockData
{
    public int[] pos;
    public float time;
}