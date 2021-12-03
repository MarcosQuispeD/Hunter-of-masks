using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationDestroy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerController.instance.itemsBonus == 5)
        {
            Destroy(gameObject);
        }
    }




}
