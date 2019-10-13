using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager INSTANCE;

    public Picture pic;

    public UnityEngine.UI.Image image;

    public List<VisibleObject> knownVisibleObjects;
    [SerializeField]
    public Camera ZoomCamera;
    [SerializeField]
    public Camera UICamera;

    [SerializeField]
    private PlayerCamera mainPlayerCamera;
    public PlayerCamera MainPlayerCamera
    {
        get
        {
            return mainPlayerCamera;
        }
        set
        {
            if (mainPlayerCamera == null)
            {
                mainPlayerCamera = value;
            }
        }
    }
    //Singleton Structure, only one Datamanger can exist
    void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(this);
        }
    }

}
