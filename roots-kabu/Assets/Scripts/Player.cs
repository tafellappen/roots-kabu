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




    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float jumpPower = 10.0f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    [SerializeField] int invincibilityFrames;
    int invincibilityCountdown;
    private Rigidbody2D body;
    //private Animator animator;
    private BoxCollider2D boxCollider;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 positionDiff;

    //LineRenderer mainLineRenderer;
    //private GameObject brush;
    //int pointCount = 0;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        //mainLineRenderer = GetComponent<LineRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //invincibilityCountdown = invincibilityFrames;
        positionDiff =  mainCamera.transform.position - transform.position;
        //mainLineRenderer.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
       


    }

    void FixedUpdate()
    {
        //Camera Movement
        //mainCamera.transform.position = transform.position + positionDiff;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        body.velocity = new Vector3(horizontalInput * speed, verticalInput * speed, 0);

        //mainLineRenderer.SetPosition(pointCount, gameObject.transform.position);

        //pointCount++;
        //mainLineRenderer.positionCount++;

    }

    private void OnCollisionEnter2D(Collision2D collision) //this will not run unless IsTrigger is true in the collider (which disables other collision like with the ground, so we probably dont want to do that)
    {
        //if (collision.gameObject.tag == "Ground")
        //{
        //}
    }


}
