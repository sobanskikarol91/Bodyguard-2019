using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = GameManager.instance.Player.transform;
    }

    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
