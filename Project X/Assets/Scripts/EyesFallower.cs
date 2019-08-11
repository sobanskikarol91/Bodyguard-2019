using UnityEngine;

public class EyesFallower : MonoBehaviour
{
    [SerializeField] float distance = 1f;

    private void Update()
    {
        Vector2 direction = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform().Rotating.Direction;
        transform.localPosition = direction.normalized * distance;
    }
}