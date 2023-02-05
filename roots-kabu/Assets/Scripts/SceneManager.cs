using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //needs to decide where to spawn nutrients
    [SerializeField] int nutrientSpawnInterval;
    int frameCount = 0;
    [SerializeField] Camera mainCamera;


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

    }
}
