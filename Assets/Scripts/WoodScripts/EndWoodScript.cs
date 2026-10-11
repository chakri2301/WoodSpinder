using UnityEngine;

public class EndWoodScript : WoodScript
{
    public GameObject levelCompleteUI;
    public LevelCompleteUi levelCompleteUi;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0;
        base.OnTriggerEnter2D(collision);
    }
}
