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
        transform.position = new Vector3(0, -5.83f, 0);
        //SceneManager sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        //if (sceneManager != null)
        //{
        //    scrollSpeed = sceneManager.UpwardsMoveSpeed;
        //}
        //else {

        //}
        scrollSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y + scrollSpeed,
                                         transform.position.z);
        if (transform.position.y > 5.68f) {
            transform.position = new Vector3(0,-5.83f,0);
        }
    }
}
