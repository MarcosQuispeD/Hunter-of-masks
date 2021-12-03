using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isGround;
    public float groundCheckRadio;
    bool isDamage;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadio,whatIsGround);
        if (isGround)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }
        FlipCharacter();
        Attack();
    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    public void Jump()
    {
        if (Input.GetButton("Jump") && isGround && !isDamage)
        {
            rb.AddForce(Vector2.up* jumpForce,ForceMode2D.Impulse);
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isDamage)
        {
            anim.SetBool("Attack_1", true);
            StartCoroutine(Damager());
            
        }
        else
        {
            anim.SetBool("Attack_1", false);
        }

    }

    public void FlipCharacter()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }

    public void Movement()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        if (isGround)
        {
            if (rb.velocity.x != 0)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
    
    }

    IEnumerator Damager()
    {

        isDamage = true;
        yield return new WaitForSeconds(0.5f);
        isDamage = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatformMovement")
        {
            rb.velocity = new Vector3(0f,0f,0f);
            gameObject.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatformMovement")
        {
            gameObject.transform.parent = null;
        }
    }

}
