using UnityEngine;
using UnityEngine.UI;

public class CircleBar : MonoBehaviour, IRestart
{
    private Image circle;

    private void Awake()
    {
        circle = GetComponent<Image>();
    }

    public void UpdateCircle(float fillValue, float maxValue)
    {
        circle.fillAmount = fillValue / maxValue;
    }

    public void OnRestart()
    {
        circle.fillAmount = 0;
    }
}
