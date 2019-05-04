using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        // hide the menu at start
        show(false);

    }

    // Update is called once per frame
    void Update()
    {
        show(PlayerControl.dead);
    }

    void show(bool active)
    {
        foreach (GameObject obj in MenuObjects)
            obj.SetActive(active);
    }
}
