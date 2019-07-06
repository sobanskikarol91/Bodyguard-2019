using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreTxt;

    int score = 0;


    public void AddScore(int amount = 1)
    {
        score += amount;
        scoreTxt.text = "Score: " + score;
    }
}