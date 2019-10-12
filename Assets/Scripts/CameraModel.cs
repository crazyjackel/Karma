using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour
{
    public Vector3[] path;
    public float animTime;
    public float speed;
    public bool canTakePhoto;
    
    private float currentTime;
    private void Start()
    {
        path[0] = this.transform.position;
        for (int i = 1;i<path.Length;i++)
        {
            path[i] += transform.parent.position;
        }
    }
    void Update()
    {
        //Checks if currenTime is greater than the animations time - 1
        if (currentTime > animTime-1)
        {
            DataManager.INSTANCE.ZoomCamera.fieldOfView = Mathf.Lerp(26.99147f,10,currentTime-(animTime-1));
            DataManager.INSTANCE.ZoomCamera.depth = 12;
        }
        else
        {
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
}
