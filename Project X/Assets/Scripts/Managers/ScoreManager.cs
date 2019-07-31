using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreTxt;

    private int score = 0;
    private ExpierienceManager expierienceManager;
    public delegate void UpdateScore(float score);
    public event UpdateScore ScoreAdded;


    private void Awake()
    {
        expierienceManager = GetComponent<ExpierienceManager>();
    }

    public void AddScore(int amount = 1)
    {
        score += amount;
        expierienceManager?.AddExpierience(amount);
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