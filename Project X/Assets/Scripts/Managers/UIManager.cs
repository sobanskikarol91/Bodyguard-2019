using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver;

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOver.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}