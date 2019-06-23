using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Joystick : MonoBehaviour
{
    [SerializeField] Transform circle;
    [SerializeField] Transform innerCircle;

    private Vector2 pressPos, currentFingerPos;
    private new Camera camera;
    private bool isPressed;
    private Transform player;

    protected Vector2 MoveDirection { get; private set; }

    private void Awake()
    {
        player = GameManager.instance.Player.transform;
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
        if (Input.GetMouseButtonDown(0) && IsTouchConditionMet())
            OnMouseButtonDown();
        else if (Input.GetMouseButton(0) && IsTouchConditionMet())
            OnDrag();
        else if (Input.GetMouseButtonUp(0) && IsTouchConditionMet())
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
        if (isPressed)
            UpdateJoystickPosition();
    }

    private void UpdateJoystickPosition()
    {
        MoveDirection = Vector2.ClampMagnitude(currentFingerPos - pressPos, 1f);
        innerCircle.transform.position = pressPos + MoveDirection;
    }

    protected abstract bool IsTouchConditionMet();
}
