using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPointController : MonoBehaviour
{
    bool isTake;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTake)
        {
            if (gameObject.CompareTag("ItemBonusCamera"))
            {
                CameraController.instance.maxCamera = 0;
            }
            else
            {
                GameManagerController.instance.AddItems();
                isTake = true;
                Destroy(gameObject);
            }
        }
    }
}
