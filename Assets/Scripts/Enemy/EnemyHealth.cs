using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool isDamage;
    EnemyController enemy;
    SpriteRenderer sprite;
    Blink material;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyController>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var detect = false;
        if (gameObject.GetComponentInChildren<Detection>() != null)
        {
            detect = gameObject.GetComponentInChildren<Detection>().isDetect;
        }
        if (collision.CompareTag("Weapon") && !isDamage && !detect)
        {
            enemy.healthPoints -= 3f;

            StartCoroutine(Damager());

            if (enemy.healthPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damager()
    {
       
        isDamage = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.9f);
        isDamage = false;
        sprite.material = material.defaultMaterial;
    }

}
