using System;
using UnityEngine;


public class EnemyScreenArrow : MonoBehaviour
{
    [SerializeField] Vector2 offsetFromBoundry = Vector2.one;

    private SpriteRenderer enemy;
    private SpriteRenderer[] sprites;
    private Bounds bounds;
    private Bounds cameraBounds;
    private new Camera camera;

    private void Start()
    {
        camera = Camera.main;
        GetReferences();
    }

    private void Update()
    {
        CheckVisible();
        GetScreenBoundry();
        SetPositionOnScreenBoundry();
    }

    private void GetReferences()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    private void GetScreenBoundry()
    {
        bounds = camera.GetBounds();
        bounds = new Bounds(bounds.center, bounds.size - (Vector3)offsetFromBoundry);
    }

    private void SetPositionOnScreenBoundry()
    {
        Vector3 clampedPosition = enemy.transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, bounds.min.x, bounds.max.x );
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bounds.min.y, bounds.max.y );
        transform.position = clampedPosition;
    }

    private void CheckVisible()
    {
        if (enemy.isVisible)
            HideSprites();
        else
            ShowSprites();
    }

    private void ShowSprites()
    {
        Array.ForEach(sprites, s => s.enabled = true);
    }

    private void HideSprites()
    {
        Array.ForEach(sprites, s => s.enabled = false);
    }

    public void SetTarget(Transform target)
    {
        enemy = target.GetComponent<SpriteRenderer>();
    }
}