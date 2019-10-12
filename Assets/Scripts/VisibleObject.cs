using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventEnum
{
    NONE, COOLHAT
}

public class VisibleObject : MonoBehaviour
{ 
    public EventEnum specialTag = EventEnum.NONE;
    public bool visible { get; private set; }
    [SerializeField]
    public float Karma = 0;

    private void Start()
    {
        DataManager.INSTANCE.knownVisibleObjects.Add(this);
    }
    void OnBecameVisible()
    {
        visible = true;
    }

    private void OnBecameInvisible()
    {
        visible = false;
    }
}
