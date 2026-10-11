using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const float WORLD_TO_JSON_SCALE = 4;
    private static GameManager Instance;
    //public GameObject[] Objects;
    public BaseSpawner[] Objects;
    public Transform ObjectsParent;
    public GameObject endTile;
    public GameObject topEdge;
    public CameraScript camScript;
    public GameObject LoadingScreen;
    void Start()
    {
        string levelURI = "http://localhost:8080/";
        LoadingScreen.SetActive(true);
        StartCoroutine(GetAndCreateLevelAsJson(levelURI + LevelManager.getInstance().getURIparams()));
    }
    
    public void LoadNextLevel()
    {
        LevelManager.getInstance().setNextLevel(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void ReplayLevel()
    {
        LevelManager.getInstance().setNextLevel(true);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    void CreateLevelFromJson(string data)
    {
        LevelData ld = JsonUtility.FromJson<LevelData>(data);
        //Debug.Log(ld);
        LevelManager.getInstance().SetCurrentCode(ld.code);
        SetEnd(ld.end / WORLD_TO_JSON_SCALE);
        //print(data);
        for (int i = 0; i < ld.items; i++)
        {
            Objects[ld.type[i]].SpawnBlock(ld.data[i], ObjectsParent);
        }
        LoadingScreen.SetActive(false);
    }
    void SetEnd(float y)
    {
        endTile.transform.position = new Vector3(0, y, 0);
        topEdge.transform.position = new Vector3(0, y + 4, 0);
        camScript.topEnd = y + 4;
    }
    IEnumerator GetAndCreateLevelAsJson(string uri)
    {
        UnityWebRequest wr = UnityWebRequest.Get(uri);
        yield return wr.SendWebRequest();
        switch (wr.result)
        {
            case UnityWebRequest.Result.Success:
                CreateLevelFromJson(wr.downloadHandler.text);
                break;
            default:
                Debug.Log(wr.result + "error " + wr.error);
                break;
        }
    }
    public static GameManager getInstance()
    {
        return Instance;
    }
}
[Serializable]
public class LevelData
{
    public int items;//total items
    public string code;
    public int[] type;
    public string[] data;
    public int end;
}
[Serializable]
public class BasicBlockData
{
    public int x;
    public int y;
    public int s;
    const float multiplier = 0.25f;
    public float X
    { get { return x * multiplier; } }
    public float Y
    { get { return y * multiplier; } }
    public float S
    { get { return multiplier * s; } }
}

