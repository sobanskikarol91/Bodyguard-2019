using UnityEngine;

public class RepellingOnCollision : MonoBehaviour
{
    [SerializeField] float force = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")  return;

        //Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector3 direction = (Vector3)collision.contacts[0].point - transform.position;
        //rb.AddForce(direction * force, ForceMode2D.Impulse);
        collision.transform.position += direction * force;
    }
}