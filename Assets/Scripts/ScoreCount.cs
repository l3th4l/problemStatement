using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public int Score = -1;

    public void addScore(int _score)
    {
        print(Score);
        Score += _score;
    }
}
