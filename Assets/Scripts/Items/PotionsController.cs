using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsController : MonoBehaviour
{

    public float healthGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().health += healthGive;
            Destroy(gameObject);
        }
    }

}
