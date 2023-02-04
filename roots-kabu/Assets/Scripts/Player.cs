using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Camera mainCamera;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }




    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpPower = 10.0f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    [SerializeField] int invincibilityFrames;
    int invincibilityCountdown;
    private Rigidbody2D body;
    //private Animator animator;
    private BoxCollider2D boxCollider;

    private float wallJumpCD;


    private float horizontalInput;

    private Vector3 positionDiff;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //invincibilityCountdown = invincibilityFrames;
        positionDiff =  mainCamera.transform.position - transform.position;
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        //make a new vector and only copy the up-down position, we dont want camera to follow the player left-right
        mainCamera.transform.position = transform.position + positionDiff;
        invincibilityCountdown -= 1;

        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;

        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


    }



    private void OnCollisionEnter2D(Collision2D collision) //this will not run unless IsTrigger is true in the collider (which disables other collision like with the ground, so we probably dont want to do that)
    {
        //if (collision.gameObject.tag == "Ground")
        //{
        //}
    }


}
