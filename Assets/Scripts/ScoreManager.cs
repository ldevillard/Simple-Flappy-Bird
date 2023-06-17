using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static public ScoreManager Instance;

    public int score;
    public int highScore;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        score = 0;
        if (PlayerPrefs.HasKey("HighScore"))
            highScore = PlayerPrefs.GetInt("HighScore");
        else
            highScore = 0;
    }

    public void AddScore()
    {
        score++;
        UIManager.Instance.UpdateScore(score);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
