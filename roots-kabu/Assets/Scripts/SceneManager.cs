using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //needs to decide where to spawn nutrients
    [SerializeField] int nutrientSpawnInterval;
    int originalNutrientSpawnInterval;
    int frameCount = 0;
    [SerializeField] GameObject nutrientPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] Camera mainCamera;

    //stuff to manage spawned objects
    [SerializeField] float upwardsMoveSpeed;
    [SerializeField] float maxUpwardsYPosition;
    [SerializeField] float spawnAreaMaxX;
    //we can cheat and say the negative of the max upwards position is probably gonna also be offscreen, below the screen
    public float UpwardsMoveSpeed
    {
        get {
            // make the speed faster as the progress goes
            GameObject obj = GameObject.FindGameObjectWithTag("HealthBar");
            if (obj != null)
            {
                HealthBar healthBar = obj.GetComponent<HealthBar>();
                float speed = upwardsMoveSpeed * (1.0f + Mathf.Sqrt(healthBar.score / 300.0f));
                return speed;
            }
            else {
                return upwardsMoveSpeed;
            }

        }
    }

    public float MaxUpwardsYPosition
    {
        get { return maxUpwardsYPosition; }
    }


    // Start is called before the first frame update
    void Start()
    {
        originalNutrientSpawnInterval = nutrientSpawnInterval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // make the nutrition more often as the time goes
        GameObject obj = GameObject.FindGameObjectWithTag("HealthBar");
        if (obj != null)
        {
            HealthBar healthBar = obj.GetComponent<HealthBar>();
            float scaler = (healthBar.score / 100.0f);
            if (scaler > 8.0f)
            {
                scaler = 8.0f;
            }
            nutrientSpawnInterval = (int)((float)originalNutrientSpawnInterval / scaler);
        }
           


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
            float thisy = Random.Range(1.0f, 1.2f);

            int result = Random.Range(1, 3);
            if (result == 2)
            {
                Instantiate(obstaclePrefab, new Vector3(thisX, -MaxUpwardsYPosition * thisy, 0), Quaternion.identity);
            }
            thisX = Random.Range(-spawnAreaMaxX, spawnAreaMaxX);
            Instantiate(nutrientPrefab, new Vector3(thisX, -MaxUpwardsYPosition, 0), Quaternion.identity);

        }



    }
}
