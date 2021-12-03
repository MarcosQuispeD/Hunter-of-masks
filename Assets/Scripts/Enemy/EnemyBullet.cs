using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bullet;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SpawnBullet()
    {
        anim.SetBool("IsShooting", true);
        GameObject bull = Instantiate(bullet, transform.position, transform.rotation);
        if (GetComponent<SpriteRenderer>().flipX)
        {
            bull.GetComponent<Rigidbody2D>().AddForce(new Vector2(900f, 0), ForceMode2D.Force);
        }
        else
        {
            bull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-900f, 0), ForceMode2D.Force);
        }
        DestroyBullet(bull);
    }


    public void DestroyBullet(GameObject bull)
    {
        Destroy(bull,1.5f);

    }
}
