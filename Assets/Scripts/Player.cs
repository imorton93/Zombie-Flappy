using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rigidBody;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;
    private float  restartPositionx = -257.81f;
    private float restartPositiony = 332.11f;
    private float restartPositionz = 63.77f;

    private AudioSource audioSource;

    public int score = 0;

     

    void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    private bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
            if (Input.GetMouseButton(0))
            {
                GameManager.instance.PlayerStartedGame();
                anim.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidBody.useGravity = true;
                jump = true;
            }
        }
        
    }

    private void FixedUpdate()
    {
         if (jump == true)
        {

            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            rigidBody.AddForce(new Vector2(-35, 17), ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            score++;
            Coin coin1 = other.GetComponent<Coin>();
            coin1.resetPosition();
            print(score);
        }
    }

    public void RestartPlayer()
    {
        Vector3 newPos = new Vector3(restartPositionx, restartPositiony, restartPositionz);
        transform.position = newPos;
        rigidBody.detectCollisions = true;
        rigidBody.useGravity = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        transform.Rotate(0, 0, 0);
    }
}
