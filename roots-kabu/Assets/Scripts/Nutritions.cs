using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutritions : MonoBehaviour
{
    [SerializeField] float baseHealth = 0.05f;
    float randomScale = 1;
    // Start is called before the first frame update
    void Start()
    {
        randomScale = Random.Range(100, 200) / 100.0f;
        Debug.Log(randomScale);
        transform.localScale *= randomScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            HealthBar healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
            healthBar.health += baseHealth * randomScale;
            if (healthBar.health > 1)
            {
                healthBar.health = 1.0f;
            }
            Destroy(this.gameObject);
        }

    }
}
