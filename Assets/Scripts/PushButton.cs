using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    public Transform button;
    public Transform buttonUp, buttonDown;

    public UnityEvent onPressed;
    public UnityEvent onReleased;

    public void OnPressed()
    {
        button.position = buttonDown.position;
        onPressed.Invoke();
    }

    public void OnReleased()
    {
        button.position = buttonUp.position;
        onReleased.Invoke();
    }
    
}
