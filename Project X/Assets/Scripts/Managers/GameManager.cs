using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player Player { get { return player; } }

    [SerializeField] Player player;

    private void Awake()
    {
        instance = this;
    }
}