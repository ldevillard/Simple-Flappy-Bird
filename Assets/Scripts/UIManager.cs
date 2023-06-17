using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    public CanvasGroup MainMenu;
    public CanvasGroup Gameplay;
    public CanvasGroup GameOver;

    public Text ScoreText;

    public GameObject StartButton;
    public GameObject RestartButton;

    public GameObject GameOverPanel;
    public Text GameOverScoreText;
    public Text GameOverHighScoreText;

    void Awake()
    {
        Instance = this;

        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameEnded += OnGameEnded;
    }

    void Start()
    {
        MainMenu.alpha = 1;
        Gameplay.alpha = 0;
        GameOver.alpha = 0;

        GameOver.gameObject.SetActive(false);
        Gameplay.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameEnded -= OnGameEnded;
    }

    void OnGameStarted()
    {
        MainMenu.DOFade(0, 0.2f)
        .OnComplete(() => MainMenu.gameObject.SetActive(false));
        Gameplay.gameObject.SetActive(true);
        Gameplay.DOFade(1, 0.2f);
    }

    void OnGameEnded()
    {
        Gameplay.DOFade(0, 0.2f).OnComplete(() => Gameplay.gameObject.SetActive(false));
        GameOver.gameObject.SetActive(true);
        GameOverScoreText.text = ScoreManager.Instance.score.ToString();
        GameOverHighScoreText.text = ScoreManager.Instance.highScore.ToString();
        GameOverPanel.transform.localScale = Vector3.zero;
        RestartButton.transform.localScale = Vector3.zero;
        GameOver.DOFade(1, 0.4f).SetDelay(0.5f)
        .OnComplete(() => GameOverPanel.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack)
        .OnComplete(() => RestartButton.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack)));
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
        ScoreText.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
    }

    public void TriggerStartGame()
    {
        StartButton.SetActive(false);
        GameManager.Instance.StartGame();
    }
}
