﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SteeringWheel : MonoBehaviour
{
    public Graphic UI_Element;

    public GameObject camionPlayer; 

    RectTransform rectT;
    Vector2 centerPoint;

    public float maximumSteeringAngle = 200f;
    public float wheelReleasedSpeed = 200f;

    float wheelAngle = 0f;
    float wheelPrevAngle = 0f;

    bool wheelBeingHeld = false;

    public float GetClampedValue()
    {
        return wheelAngle / maximumSteeringAngle;
    }

    public float GetAngle()
    {
        return wheelAngle;
    }

    void Start()
    {
        rectT = UI_Element.rectTransform;
        InitEventsSystem();
    }

    void Update()
    {
        if (!wheelBeingHeld && !Mathf.Approximately(0f, wheelAngle))
        {
            float deltaAngle = wheelReleasedSpeed * Time.deltaTime;
            if (Mathf.Abs(deltaAngle) > Mathf.Abs(wheelAngle))
                wheelAngle = 0f;
            else if (wheelAngle > 0f)
                wheelAngle -= deltaAngle;
            else
                wheelAngle += deltaAngle;
        }

        rectT.localEulerAngles = Vector3.back * wheelAngle;
    }

    void InitEventsSystem()
    {
        EventTrigger events = UI_Element.gameObject.GetComponent<EventTrigger>();

        if (events == null)
            events = UI_Element.gameObject.AddComponent<EventTrigger>();

        if (events.triggers == null)
            events.triggers = new System.Collections.Generic.List<EventTrigger.Entry>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.TriggerEvent callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> functionCall = new UnityAction<BaseEventData>(PressEvent);
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback = callback;

        events.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>(DragEvent);
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.Drag;
        entry.callback = callback;

        events.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        callback = new EventTrigger.TriggerEvent();
        functionCall = new UnityAction<BaseEventData>(ReleaseEvent);//
        callback.AddListener(functionCall);
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback = callback;

        events.triggers.Add(entry);
    }

    public void PressEvent(BaseEventData eventData)
    {
        Vector2 pointerPos = ((PointerEventData)eventData).position;

        wheelBeingHeld = true;
        centerPoint = RectTransformUtility.WorldToScreenPoint(((PointerEventData)eventData).pressEventCamera, rectT.position);
        wheelPrevAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);
    }

    public void DragEvent(BaseEventData eventData)
    {
        Vector2 pointerPos = ((PointerEventData)eventData).position;

        float wheelNewAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);
        if (Vector2.Distance(pointerPos, centerPoint) > 20f)
        {
            if (pointerPos.x > centerPoint.x)
                wheelAngle += wheelNewAngle - wheelPrevAngle;
            else
                wheelAngle -= wheelNewAngle - wheelPrevAngle;
        }
        wheelAngle = Mathf.Clamp(wheelAngle, -maximumSteeringAngle, maximumSteeringAngle);
        wheelPrevAngle = wheelNewAngle;

        camionPlayer.SendMessage("SetGiro", Mathf.Clamp(wheelAngle, -1, 1));

        Debug.Log("ANGULO GIRO: " + wheelAngle);
    }

    public void ReleaseEvent(BaseEventData eventData)
    {
        DragEvent(eventData);

        wheelBeingHeld = false;
    }
}