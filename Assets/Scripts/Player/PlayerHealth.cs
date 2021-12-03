using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool isInmune;
    public float inmunityTime;
    public float knockBackForceX;
    public float knockBackForceY;

    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = health / 100;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<EnemyController>().damageEnemy;

            StartCoroutine(Inmune());

            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector3(knockBackForceX, knockBackForceY,transform.position.z));
            }
            else
            {
                rb.AddForce(new Vector3(-knockBackForceX, knockBackForceY, transform.position.z));
            }
            IsDeathPlayer();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathDecoration") && !isInmune)
        {
            health -= 15f;
            StartCoroutine(Inmune());

            rb.AddForce(new Vector2(0, 800), ForceMode2D.Force);
            IsDeathPlayer();
        }
    }


    private void IsDeathPlayer()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
            GameManagerController.instance.ChangeScene(2);
        }
    }

    IEnumerator Inmune()
    {
        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        isInmune = false;
        sprite.material = material.defaultMaterial;
    }
}
