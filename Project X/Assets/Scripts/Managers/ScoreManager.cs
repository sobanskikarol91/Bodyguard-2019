using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class ScoreManager : MonoBehaviour, IScore, IRestart
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] CircleBar circleBar;

    private float score = 0;
    private IScore[] scorables;
    private LevelManager levelManager;

    private void Awake()
    {
        scorables = GetComponents<IScore>().Where(t => t != (IScore)this).ToArray();
        levelManager = GameManager.instance.LevelManager;
    }

    public void UpdatedScore(float amount = 1)
    {
        score += amount;
        UpdateUIText();
        Array.ForEach(scorables, s => s.UpdatedScore(score));
        UpdateCircleBar();
    }

    private void UpdateCircleBar()
    {
        if (levelManager.IsLastLvl()) return;

        float previousLvl = levelManager.PreviousLvlValue;
        float nextLvl = levelManager.NextLvlValue - previousLvl;
        float scoreInLvl = score - previousLvl;

        circleBar.UpdateCircle(scoreInLvl, nextLvl);
    }

    private void UpdateUIText()
    {
        scoreTxt.text = score.ToString();
    }

    public void OnRestart()
    {
        score = 0;
        UpdateUIText();
        circleBar.OnRestart();
    }
}