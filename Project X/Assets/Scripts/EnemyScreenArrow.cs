using System;
using UnityEngine;


public class EnemyScreenArrow : MonoBehaviour
{
    [SerializeField] Vector2 offsetFromBoundry = Vector2.one;

    private SpriteRenderer target;
    private SpriteRenderer[] sprites;
    private Bounds bounds;
    private Bounds cameraBounds;


    private void Start()
    {
        GetReferences();
        GetScreenBoundry();
    }

    private void Update()
    {
        CheckVisible();
        SetPositionOnScreenBoundry();
    }

    private void GetReferences()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    private void GetScreenBoundry()
    {
        bounds = Camera.main.GetBounds();
        bounds = new Bounds(bounds.center, bounds.size - (Vector3)offsetFromBoundry);
    }

    private void SetPositionOnScreenBoundry()
    {
        Vector3 clampedPosition = target.transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, bounds.min.x, bounds.max.x );
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bounds.min.y, bounds.max.y );
        transform.position = clampedPosition;
    }

    private void CheckVisible()
    {
        if (target.isVisible)
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
        this.target = target.GetComponent<SpriteRenderer>();
    }
}