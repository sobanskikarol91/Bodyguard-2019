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

    public void UpdatedScore(float amount = 1)
    {
        score += amount;
        UpdateUIText();
        Array.ForEach(scorables, s => s.UpdatedScore(score));
    }

    private void UpdateUIText()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void OnRestart()
    {
        score = 0;
        UpdateUIText();
    }
}