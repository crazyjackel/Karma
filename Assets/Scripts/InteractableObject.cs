using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent[] interactEvent;

    public void Interact()
    {
        foreach(UnityEvent unityEvent in interactEvent)
        {
            unityEvent.Invoke();
        }
    }
}
