using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutritions : MonoBehaviour
{
    [SerializeField] float baseHealth = 0.05f;
    float randomScale = 1;
    AudioSource audioSource;
    [SerializeField] AudioClip collissionSFX;

    // Start is called before the first frame update
    void Start()
    {
        randomScale = Random.Range(100, 200) / 100.0f;
        //Debug.Log(randomScale);
        transform.localScale *= randomScale;


        //we cant have the audio source on this gameobject, because when it gets deleted then it will just not play. Just put it on camera for now
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            GameObject obj = GameObject.FindGameObjectWithTag("HealthBar");
            if (obj != null)
            {
                HealthBar healthBar = obj.GetComponent<HealthBar>();
                healthBar.health += baseHealth * randomScale;

                //if (baseHealth > 0)
                //{
                //    audioSource.clip = getHealth;

                //}
                //else if (baseHealth < 0)
                //{
                //    audioSource.clip = getHurt;
                //}
                audioSource.clip = collissionSFX; //set the camera audio source to play whatever clip is assigned to this script
                audioSource.Play();
                if (healthBar.health > 1)
                {
                    healthBar.health = 1.0f;
                }
            }


            Destroy(this.gameObject);
        }

    }
}
