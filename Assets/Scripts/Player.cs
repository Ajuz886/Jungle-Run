using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;
    public LayerMask ground;
    public LayerMask deathGround;

    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private Animator animator;

    public AudioSource deathSound;
    public AudioSource jumpSound;

    public float mileStone;
    private float mileStoneCount;
    public float speedMultiplier;

    public GameManager gameManager;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        mileStoneCount = mileStone;

    }

    void Update()
    {
        bool dead = Physics2D.IsTouchingLayers(playerCollider, deathGround);

        if (dead)
        {
            GameOver();
        }

        if (transform.position.x > mileStoneCount)
        {
            mileStoneCount += mileStone;
            speed = speed * speedMultiplier;
            mileStone += mileStone * speedMultiplier;
            Debug.Log("M" + mileStone + ", MC" + mileStoneCount + ",MS" + speed);
        }

        rigidBody.linearVelocity = new Vector2(speed, rigidBody.linearVelocity.y);

        bool grounded = Physics2D.IsTouchingLayers(playerCollider, ground);


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (grounded)
                jumpSound.Play();
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jump);

        }
        animator.SetBool("Grounded", grounded);
    }
    void GameOver()
    {
        gameManager.GameOver();
    }
}
