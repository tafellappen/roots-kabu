using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //needs to decide where to spawn nutrients
    [SerializeField] int nutrientSpawnInterval;
    int frameCount = 0;
    [SerializeField] GameObject nutrientPrefab;
    [SerializeField] Camera mainCamera;

    //stuff to manage spawned objects
    [SerializeField] float upwardsMoveSpeed;
    [SerializeField] float maxUpwardsYPosition;
    [SerializeField] float spawnAreaMaxX;
    //we can cheat and say the negative of the max upwards position is probably gonna also be offscreen, below the screen
    public float UpwardsMoveSpeed
    {
        get { return upwardsMoveSpeed; }
    }

    public float MaxUpwardsYPosition
    {
        get { return maxUpwardsYPosition; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;

        if (frameCount >= nutrientSpawnInterval)
        {
            SpawnNutrients();
        }
    }

    void SpawnNutrients()
    {
        if(frameCount >= nutrientSpawnInterval)
        {
            frameCount = 0;

            float thisX = Random.Range(-spawnAreaMaxX, spawnAreaMaxX);

            Instantiate(nutrientPrefab, new Vector3(thisX, -MaxUpwardsYPosition, 0), Quaternion.identity);

        }



    }
}
