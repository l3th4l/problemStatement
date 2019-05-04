using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    ScoreCount ScoreCounter;
    [SerializeField]
    Text ScoreDisplayText;
    [SerializeField]
    Button ResetButton;
    [SerializeField]
    Button MainMenuButton;

    [SerializeField]
    List<GameObject> MenuObjects;

    [SerializeField]
    CharControl PlayerControl;

    LoadResetLevel levelControl;

    // Start is called before the first frame update
    void Start()
    {
        // hide the menu at start
        show(false);
        levelControl = GetComponent<LoadResetLevel>();
        ResetButton.onClick.AddListener(resetScene);
        MainMenuButton.onClick.AddListener(loadMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        show(PlayerControl.dead);
        ScoreDisplayText.text = ScoreCounter.Score.ToString();
    }

    void show(bool active)
    {
        foreach (GameObject obj in MenuObjects)
            obj.SetActive(active);
    }
    void resetScene()
    {
        levelControl.resetScene();
    }
    void loadMainMenu()
    {
        levelControl.loadMainMenu();
    }
}
