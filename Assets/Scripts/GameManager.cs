using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static bool IsPause = false;
    [SerializeField] private GameObject pausePanel;


    private void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
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
}
