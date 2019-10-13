using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Picture{
    public Texture2D pic;
    public List<VisibleObject> FoundObjects;
    float karma;
    public float CalculateKarma()
    {
        karma = 0;
        if (FoundObjects != null) { 
        foreach(VisibleObject visible in FoundObjects)
        {
            karma += visible.Karma;
        }
        }
        return karma;
    }
}

public class CameraModel : MonoBehaviour
{
    public Vector3[] path;
    
    public float animTime;
    public float speed;
    public bool canTakePhoto = false;
    private bool takeNextFrame = false;
    private float currentTime;


    private void Start()
    {
        path[0] = this.transform.position;
        for (int i = 1;i<path.Length;i++)
        {
            path[i] += transform.parent.position;
        }
    }

    //Takes the Photos, disables gui for good photos
    private void FixedUpdate()
    {
        if (takeNextFrame)
        {
            takeNextFrame = false;
            TakePhoto();
        }
        if (Input.GetMouseButtonDown(0) && canTakePhoto)
        {
            takeNextFrame = true;
            DataManager.INSTANCE.image.enabled = false;
        }
        
    }
    void Update()
    {
        
        //Checks if currenTime is greater than the animations time - 1
        if (currentTime > animTime-1)
        {
            canTakePhoto = true;
            DataManager.INSTANCE.ZoomCamera.transform.position = DataManager.INSTANCE.MainPlayerCamera.transform.position;
            DataManager.INSTANCE.ZoomCamera.transform.rotation = DataManager.INSTANCE.MainPlayerCamera.transform.rotation;
            DataManager.INSTANCE.ZoomCamera.fieldOfView = Mathf.Lerp(26.99147f,10,currentTime-(animTime-1));
            DataManager.INSTANCE.ZoomCamera.depth = 12;
        }
        else
        {
            canTakePhoto = false;
            DataManager.INSTANCE.ZoomCamera.fieldOfView = 26.99147f;
            DataManager.INSTANCE.ZoomCamera.depth = -12;
        }
        currentTime = Mathf.Clamp(currentTime, 0, animTime + 1);

        //Gets Goto Index
        int index = Mathf.Clamp((int)(path.Length * currentTime / animTime), 0, path.Length - 1);

        //If button down, set time, if button up set time
        if (Input.GetMouseButtonDown(1))
        {
            currentTime = animTime / (path.Length - 1);
        }
        if (Input.GetMouseButtonUp(1))
        {
            currentTime = index * (animTime / path.Length - 1);
        }
        if (Input.GetMouseButton(1))
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
        transform.position = Vector3.Lerp(transform.position, path[index], Time.deltaTime * speed);
        
    }

    void TakePhoto()
    {
        Picture p = new Picture();
        p.FoundObjects = new List<VisibleObject>();
        foreach (VisibleObject v in DataManager.INSTANCE.knownVisibleObjects)
        {
            if (v.visible)
            {
                p.FoundObjects.Add(v);
            }
        }
        p.pic = ScreenCapture.CaptureScreenshotAsTexture();
        DataManager.INSTANCE.image.enabled = true;
        Sprite mySprite = Sprite.Create(p.pic, new Rect(0.0f, 0.0f, p.pic.width, p.pic.height), new Vector2(0.5f, 0.5f), 100.0f);
        DataManager.INSTANCE.image.sprite = mySprite;
        Debug.Log(p.CalculateKarma());
       
    }
}
