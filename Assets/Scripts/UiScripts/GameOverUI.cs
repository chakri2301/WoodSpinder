using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class GameOverUI : MonoBehaviour
{
//LevelComplete Comtrols
    public VisualElement ui;
    public Button replayButton;
    public Button anotherLevelButton;
    public GameManager gm;
    public UIScript uIScript;
    Label starInfo;
    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }
    public void OnEnable()
    {
        replayButton= ui.Q<Button>("Retry");
        replayButton.clicked += OnReplayClicked;
        anotherLevelButton = ui.Q<Button>("PlayAnotherLevel");
        anotherLevelButton.clicked += OnAnotherClicked;
        starInfo = ui.Q<Label>("StarInfo");
        starInfo.text = "Stars Collected: " + uIScript.starsCount;
    }
    void OnReplayClicked()
    {
        gm.ReplayLevel();
        gameObject.SetActive(false);
    }
    void OnAnotherClicked()
    {
        gm.LoadNextLevel();
        gameObject.SetActive(false);
    }
}
