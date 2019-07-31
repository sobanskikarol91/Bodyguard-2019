using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreTxt;

    private int score = 0;
    public delegate void UpdateScore(float score);
    public event UpdateScore ScoreAdded;


    public void AddScore(int amount = 1)
    {
        score += amount;
        UpdateUIText();
        ScoreAdded(score);
    }

    private void UpdateUIText()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void Reset()
    {
        score = 0;
        UpdateUIText();
    }
}