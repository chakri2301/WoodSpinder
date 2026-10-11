using UnityEngine;
using UnityEngine.UIElements;

public class LevelCompleteUi : MonoBehaviour
{
//LevelComplete Comtrols
    public VisualElement ui;
    Button playAnotherButton;
    Button playAgainButton; 
    public GameManager gm;
    public UIScript uIScript;
    Label starInfo;
    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }
    public void OnEnable()
    {
        playAnotherButton= ui.Q<Button>("PlayAnother");
        playAnotherButton.clicked += OnPlayButton;
        playAgainButton= ui.Q<Button>("PlayAgain");
        playAgainButton.clicked += OnPlayAgain;
        starInfo = ui.Q<Label>("StarInfo");
        starInfo.text = "Stars Collected: " + uIScript.starsCount;
    }
    void OnPlayButton()
    {
        gm.LoadNextLevel();
        gameObject.SetActive(false);
    }
    void OnPlayAgain()
    {
        gm.ReplayLevel();
        gameObject.SetActive(false);
    }
}
