﻿using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    [Header("Fixed Joystick")]
    

    Vector2 joystickPosition = Vector2.zero;
    private Camera cam = new Camera();

    void Start()
    {
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        Vector2 direction = eventData.position - joystickPosition;
        inputVector = (direction.magnitude > background.sizeDelta.x / 5f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 5f) * handleLimit;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        OnDrag(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}