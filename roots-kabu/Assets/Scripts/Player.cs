using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    //[SerializeField] private Camera mainCamera;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    [SerializeField] private bool isTitleScreen = false;


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
        //positionDiff =  mainCamera.transform.position - transform.position;
        //mainLineRenderer.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
       


    }

    bool playerStartMoving = false;
    int baseFrameCount = 60;
    int frameCount = 30;
    int currentFrame = 0;
    float titleScreenSpeed = 1.0f;
    void FixedUpdate()
    {
        //Camera Movement
        //mainCamera.transform.position = transform.position + positionDiff;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = 0.0f;// Input.GetAxis("Vertical");

        body.velocity = new Vector3(horizontalInput * speed, verticalInput * speed, 0);
        if (horizontalInput != 0) {
            playerStartMoving = true;
        }
        if (isTitleScreen) {
            if (!playerStartMoving) {
                float speedFactor = Random.Range(1.0f, 2.0f);
                body.velocity = new Vector3(1 * titleScreenSpeed * speedFactor, verticalInput * speed, 0);
                currentFrame++;
                if (currentFrame >= frameCount) {
                    float frameFactor = Random.Range(1.0f, 2.0f);
                    frameCount = (int)((float)baseFrameCount * frameFactor);
                    titleScreenSpeed *= -1;
                    currentFrame = 0;
                }
            }
        }
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
