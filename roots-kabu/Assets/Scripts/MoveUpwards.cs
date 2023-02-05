using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Everything that isnt the player should be moving upwards, to give the illusion of downward movement
/// </summary>
public class MoveUpwards : MonoBehaviour
{
    float upwardsMoveSpeed;
    float maxYPosition;
    Player player;
    SceneManager sceneManager;

    //not using a vector because i am lazy and this cleans up the code for setting the position later on
    float xPosition;
    float yPosition;
    float zPosition;

    // Start is called before the first frame update
    void Start()
    {
        //find player in scene here
        player = GameObject.Find("Player").GetComponent<Player>();
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();

        upwardsMoveSpeed = sceneManager.UpwardsMoveSpeed;
        maxYPosition = sceneManager.MaxUpwardsYPosition;

        xPosition = transform.position.x;
        yPosition = transform.position.y;
        zPosition = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        yPosition += upwardsMoveSpeed;
        transform.position = new Vector3(xPosition, yPosition, zPosition);

        //Everything that moves upwards should delete itself upon moving too far from the player, or at least as soon as it gets out of camera view
        

        if (yPosition >= maxYPosition)
        {
            Destroy(gameObject);
        }
    }
}
