using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action OnStart;
    public bool IsPause = false;
    public bool isGameStart = false;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private TextMeshProUGUI finalResult;
    public ScoreCounter ScoreCounter;

    private void OnValidate()
    {
        if (!ScoreCounter)
        {
            ScoreCounter = FindObjectOfType<ScoreCounter>();
        }
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        finalPanel.SetActive(false);
        isGameStart = true;
        Time.timeScale = 1;
        OnStart?.Invoke();
    }

    public void TogglePause()
    {
        IsPause = !IsPause;
        Time.timeScale = IsPause ? 0 : 1;
        pausePanel.SetActive(IsPause);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void GameOver()
    {
        finalPanel.SetActive(true);
        ShowResult();
        isGameStart = false;
    }

    private void ShowResult()
    {
        finalResult.text = "Final Score: " + ScoreCounter.Score.ToString("n1");
    }
}
