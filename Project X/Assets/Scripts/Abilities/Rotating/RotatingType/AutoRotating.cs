using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "AutoRotating", menuName = "Rotating/AutoRotating")]
public class AutoRotating : RotateType
{
    [SerializeField] float speed;

    private Transform transform;

    public override void Init(RotatingAbility ability)
    {
        base.Init(ability);
        transform = ability.transform;
        ability.StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            Debug.Log("Before" + transform.rotation.eulerAngles.z);
            float angle = transform.rotation.eulerAngles.z + Time.deltaTime * speed;
            Vector3 rotation = new Vector3(0, 0, angle);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            yield return null;
        }
    }
}