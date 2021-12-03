using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;

    public bool isStatic;
    public bool isWalk;
    public bool isWalkRight;

    public Transform wallCheck, groundCheck, pitCheck;

    public bool wallDetected;
    public bool pitDetected;
    public bool groundDetected;

    public float detectionRdio;
    public LayerMask isGround;

    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<EnemyController>().speed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position,detectionRdio,isGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRdio, isGround);
        groundDetected = Physics2D.OverlapCircle(groundCheck.position, detectionRdio, isGround);

        if ((pitDetected || wallDetected) && groundDetected)
        {
            Flip();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isStatic)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void FixedUpdate()
    {
        if (isWalk)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            if (!isWalkRight)
            {
                rb.velocity = new Vector2(-speed*Time.deltaTime,rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
    }

    public void Flip()
    {
        isWalkRight = !isWalkRight;
        transform.localScale *= new Vector2(-1,transform.localScale.y);
    }
}
