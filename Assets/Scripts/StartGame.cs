using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button StartButton;
    LoadResetLevel levelControl;

    void Start()
    {
        levelControl = GetComponent<LoadResetLevel>();
        StartButton.onClick.AddListener(loadStartingLevel);
    }
    void loadStartingLevel()
    {
        levelControl.loadLevel(levelControl.main_level_index);
    }
}
