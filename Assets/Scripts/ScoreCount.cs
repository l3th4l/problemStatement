using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{

    [SerializeField]
    Text ScoreDisplayText;

    public int Score = -1;

    public void addScore(int _score)
    {
        Score += _score;
    }

    void Update()
    {
        if(Score >= 0)
        {
            ScoreDisplayText.text = "Score : " + Score.ToString();
        }
    }
}
