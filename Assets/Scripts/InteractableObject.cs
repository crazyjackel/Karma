using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent[] interactEvent;
    public int index;
    public void Interact(int indexIn)
    {
        index = Mathf.Clamp(indexIn, 0, interactEvent.Length - 1);
        interactEvent[index].Invoke();
    }

}
