using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Scorable : MonoBehaviour
{
    [SerializeField] int score;


    private void Awake()
    {
        GetComponent<IDeath>().Death += AddScore;
    }

    private void AddScore()
    {
        GameManager.instance.ScoreManager.AddScore(score);
    }
}