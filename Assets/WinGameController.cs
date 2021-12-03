using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManagerController.instance.ChangeScene(3);
        }
    }

}
