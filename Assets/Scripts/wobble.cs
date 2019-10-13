using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class wobble : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y, 10 * Mathf.Cos(Time.time / 2));
        transform.position = new Vector3(transform.position.x,1+0.5f*Mathf.Sin(Time.time), transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            StartCoroutine(LoadSceneAsync());
        }
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("SampleScene");

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
