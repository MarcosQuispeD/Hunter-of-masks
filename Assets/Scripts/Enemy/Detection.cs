using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public bool isInmune;
    public bool isDetect;
    public float timeDetect;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isDetect = true;
        if (collision.CompareTag("Player")  && !isInmune)
        {
            StartCoroutine(Inmune());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isDetect = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetComponentInParent<EnemyBullet>().anim.SetBool("IsShooting", false);
        isDetect = false;
    }

    IEnumerator Inmune()
    {
        isInmune = true;
        transform.GetComponentInParent<EnemyBullet>().SpawnBullet();
        yield return new WaitForSeconds(timeDetect);
        isInmune = false;
    }
}
