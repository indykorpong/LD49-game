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

    private void Update()
    {
        score = player.transform.position.y * 10;
        scoreText.text = score + " M";
    }
}
