using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
