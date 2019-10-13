using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent[][] interactEvent;
    int index;
    public void Interact()
    {
        index = Mathf.Clamp(index, 0, interactEvent.Length - 1);
        foreach(UnityEvent unityEvent in interactEvent[index])
        {
            unityEvent.Invoke();
        }
    }
}
