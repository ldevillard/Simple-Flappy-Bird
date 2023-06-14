using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    static public event Action OnGameStarted;

    public enum GameState
    {
        MainMenu,
        Playing,
        GameOver
    }

    public GameState CurrentGameState;

    public float speedPipe;
    public float numberPipes;
    public float distanceBetweenPipes;

    public Pipe pipePrefab;

    public Transform pipeSpawnPoint;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CurrentGameState = GameState.MainMenu;

        for (int i = 0; i < numberPipes; i++)
        {
            Pipe pipe = Instantiate(pipePrefab, pipeSpawnPoint.position + new Vector3(i * distanceBetweenPipes, 0, 0), Quaternion.identity);
        }
    }

    public void StartGame()
    {
        CurrentGameState = GameState.Playing;
        OnGameStarted?.Invoke();
    }

    public void GameOver()
    {
        CurrentGameState = GameState.GameOver;
    }
}
