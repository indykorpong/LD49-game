using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float score;
    [SerializeField] private GameObject player;

    public float Score => score;

    private void Update()
    {
        if(!GameManager.Instance.isGameStart) return;
        
        score = player.transform.position.y * 10;
        scoreText.text = score + " M";
    }
}
