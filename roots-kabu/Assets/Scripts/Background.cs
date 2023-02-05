using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{

    // Start is called before the first frame update
    float scrollSpeed;
    void Start()
    {
        transform.position = new Vector3(0, -5.7f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
        GameObject obj = GameObject.Find("SceneManager");
        if (obj != null)
        {
            SceneManager sceneManager = obj.GetComponent<SceneManager>();
            scrollSpeed = sceneManager.UpwardsMoveSpeed;
        }
        else
        {
            scrollSpeed = 0.05f;
        }
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y + scrollSpeed,
                                         transform.position.z);
        if (transform.position.y > 5.7f) {
            transform.position = new Vector3(0,-5.7f,0);
        }
    }
}
