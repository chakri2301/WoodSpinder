using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject helpUi;
    public GameObject[] stars;
    public GameObject[] lives;
    public int starsCount = 0;
    int livesCount = 3;
    public GameObject gameOverScreen;
    public GameOverUI gameOverUI;
    public LevelCompleteUi levelCompleteUi;
    public void ShowHelp()
    {
        helpUi.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseHelp()
    {
        helpUi.SetActive(false);
        Time.timeScale = 1f;
    }
    public void addStar()
    {
        if (starsCount >= 3) return;
        stars[starsCount].SetActive(true);
        starsCount++;
    }
    public void minusHealth()
    {
        livesCount--;
        if (livesCount <= 0)
        {
            livesCount = 0;
            print("GameOver");
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
        lives[livesCount].SetActive(false);
    }
}
