using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Joystick : MonoBehaviour, IDirectionInput
{
    [SerializeField] Transform circle;
    [SerializeField] Transform innerCircle;

    public event Action OnUse = delegate { };
    public Vector2 Direction { get; private set; }

    private Vector2 pressPos, currentFingerPos;
    private new Camera camera;
    private Transform player;



    private Touch touch;
    public int FingerId { get; private set; }


    private void Start()
    {
        player = GameManager.instance.Player.transform;
        camera = Camera.main;
    }

    private Vector3 GetWorldMousePos()
    {
        return camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, camera.transform.position.z));
    }



    private void OnMouseButtonDown()
    {
        Debug.Log("Down");
        FingerId = touch.fingerId;
        pressPos = GetWorldMousePos();
        circle.transform.position = pressPos;
        circle.gameObject.SetActive(true);
    }

    private void OnMouseButtonPressing()
    {
        Debug.Log("isTouching");
        UpdateJoystickPosition();
        currentFingerPos = GetWorldMousePos();
        OnUse();
    }

    private void OnMouseButtonUp()
    {
        Debug.Log("Up");
        FingerId = -1;
        circle.gameObject.SetActive(false);
    }

    private void UpdateJoystickPosition()
    {
        Direction = Vector2.ClampMagnitude(currentFingerPos - pressPos, 1f);
        innerCircle.transform.position = pressPos + Direction;
    }

    protected abstract bool IsTouchConditionMet();
}
