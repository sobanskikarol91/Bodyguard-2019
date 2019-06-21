using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform circle;
    [SerializeField] Transform innerCircle;

    private Vector2 pressPos;
    private Vector2 currentFingerPos;
    private new Camera camera;
    private bool isPressed;


    private void Awake()
    {
        camera = Camera.main;
    }

    private void OnDrag()
    {
        currentFingerPos = GetWorldMousePos();
    }

    private Vector3 GetWorldMousePos()
    {
        return camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.transform.position.z));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnMouseButtonDown();
        else if (Input.GetMouseButton(0))
            OnDrag();
        else if (Input.GetMouseButtonUp(0))
            OnMouseButtonUp();
    }

    private void OnMouseButtonDown()
    {
        isPressed = true;
        pressPos = GetWorldMousePos();
        circle.transform.position = pressPos;
        circle.gameObject.SetActive(true);
    }

    private void OnMouseButtonUp()
    {
        isPressed = false;
        circle.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (!isPressed) return;

        Vector2 direction = Vector2.ClampMagnitude(currentFingerPos - pressPos, 1f);
        player.Translate(direction * 5 * Time.deltaTime);
        innerCircle.transform.position = pressPos + direction;
    }
}
