using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{

    public float health = 1;
    [SerializeField] float hpReductionSpeed = 0.001f;
    [SerializeField] float scoreIncreseSpeed = 2f;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Canvas gameOverCanvas;

    public float score = 0;
    private Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.P)) {
            health = 0;
        }
        if (health > 0)
        {
            health -= hpReductionSpeed * Time.deltaTime * Mathf.Sqrt(score) * 0.6f;
            score += scoreIncreseSpeed * Time.deltaTime;
            scoreText.text = "Score: " + ((int)score).ToString();
        }
        else {
            gameOverCanvas.gameObject.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
        slider.value = health;
    }
}
