using System;
using UnityEngine;

public class EyesFallower : MonoBehaviour
{
    [SerializeField] float distance = 1f;
    [SerializeField] bool isAI;

    Func<Vector2> GetDirection;

    private void Awake()
    {
        if (isAI)
            GetDirection = () => GameManager.instance.Player.transform.position - transform.position;
        else
            GetDirection = () => GameManager.instance.Platform.GetPlayerInputDependsOnPlatform().Rotating.Direction;
    }

    private void Update()
    {
        Vector2 direction = GetDirection().normalized;
        transform.localPosition = direction * distance;
    }
}