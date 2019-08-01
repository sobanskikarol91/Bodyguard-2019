using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class ScoreManager : MonoBehaviour, IScore, IRestart
{
    [SerializeField] TextMeshPro scoreTxt;

    private float score = 0;
    private IScore[] scorables;


    private void Awake()
    {
        scorables = GetComponents<IScore>().Where(t => t != (IScore)this).ToArray();    
    }

    public void UpdateScore(float amount = 1)
    {
        score += amount;
        UpdateUIText();
        Array.ForEach(scorables, s => s.UpdateScore(score));
    }

    private void UpdateUIText()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void Restart()
    {
        score = 0;
        UpdateUIText();
    }
}