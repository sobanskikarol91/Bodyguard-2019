using UnityEngine;

public class EnemyScreenArrow : MonoBehaviour
{
    [SerializeField] Vector2 offsetFromBoundry = Vector2.one;

    private SpriteRenderer[] sprites;
    private Bounds bounds;
    private Bounds cameraBounds;
    private new Camera camera;
    private Transform target;

    private void Awake()
    {
        GetReferences();
        camera = Camera.main;
    }
    
    private void Update()
    {
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
        Vector3 clampedPosition = target.transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, bounds.min.x, bounds.max.x );
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bounds.min.y, bounds.max.y );
        transform.position = clampedPosition;
    }

    public void AssignTo(Transform transform)
    {
        target = transform;
    }
}