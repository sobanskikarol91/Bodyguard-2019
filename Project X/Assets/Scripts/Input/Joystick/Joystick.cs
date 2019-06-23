using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Joystick : MonoBehaviour, IDirectionInput
{
    [SerializeField] Transform circle;
    [SerializeField] Transform innerCircle;

    private Vector2 pressPos, currentFingerPos;
    private new Camera camera;
    private Transform player;

    public event Action OnUse = delegate { };
    public Vector2 Direction { get; private set; }


    private void Start()
    {
        SetInputDependsOnPlatform();
        player = GameManager.instance.Player.transform;
        camera = Camera.main;
    }

    private void SetInputDependsOnPlatform()
    {

    }

    private void OnMouseButtonPressing()
    {
        UpdateJoystickPosition();
        currentFingerPos = GetWorldMousePos();
        OnUse();
    }

    private Vector3 GetWorldMousePos()
    {
        return camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.transform.position.z));
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && IsTouchConditionMet())
            OnMouseButtonDown();
        else if (Input.GetMouseButton(0) && IsTouchConditionMet())
            OnMouseButtonPressing();
        else if (Input.GetMouseButtonUp(0) && IsTouchConditionMet())
            OnMouseButtonUp();
#endif
#if UNITY_ANDROID

    }

    private void OnMouseButtonDown()
    {
        pressPos = GetWorldMousePos();
        circle.transform.position = pressPos;
        circle.gameObject.SetActive(true);
    }

    private void OnMouseButtonUp()
    {
        circle.gameObject.SetActive(false);
    }

    private void UpdateJoystickPosition()
    {
        Direction = Vector2.ClampMagnitude(currentFingerPos - pressPos, 1f);
        innerCircle.transform.position = pressPos + Direction;
    }

    protected abstract bool IsTouchConditionMet();
}
