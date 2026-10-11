using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager Instance;
    bool isReplayNext = false;
    string currentCode = "";
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public static LevelManager getInstance()
    {
        return Instance;
    }
    public string getURIparams()
    {
        if (isReplayNext)
        {
            return "r?code=" + currentCode;

        }
        else
        {
            if (currentCode == "")
            {
                return "c";
            }
            else
            {
                return "n";
            }
        }
    }
    public void setNextLevel(bool isReplay)
    {
        isReplayNext = isReplay;
    }
    public void SetCurrentCode(string code)
    {
        currentCode = code;
    }
    public string GetCurrentCode()
    {
        return currentCode;
    }
}
