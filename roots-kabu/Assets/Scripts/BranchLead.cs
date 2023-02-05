using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchLead : MonoBehaviour
{
    //public float speed { get; set; }
    [SerializeField] float speed;

    SceneManager sceneManager;

    //not using a vector because i am lazy and this cleans up the code for setting the position later on
    float xPosition;
    float yPosition;
    float zPosition;

    float sidewaysMoveSpeed;
    float maxXPosition;

    private void Awake()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();

        sidewaysMoveSpeed = sceneManager.UpwardsMoveSpeed;
        maxXPosition = sceneManager.MaxUpwardsYPosition;

        xPosition = transform.position.x;
        yPosition = transform.position.y;
        zPosition = transform.position.z;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xPosition += sidewaysMoveSpeed;
        transform.position = new Vector3(xPosition, yPosition, zPosition);
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            
            Destroy(gameObject);
        }
    }
}
