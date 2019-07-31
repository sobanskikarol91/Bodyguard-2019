using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
}