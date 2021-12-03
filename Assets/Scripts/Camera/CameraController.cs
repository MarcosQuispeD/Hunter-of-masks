using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Transform roomCamera;
    public float maxCamera;

    public static CameraController instance;

    [Range(-50, 50)]
    public float minModX, maxModX, minModY, maxModY;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var minPosY = roomCamera.GetComponent<BoxCollider2D>().bounds.min.y+ minModY;
        var minPosX = roomCamera.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosY = roomCamera.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var maxPosx = roomCamera.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;


        Vector3 cameraPos = new Vector3(
            Mathf.Clamp(player.position.x,minPosX,maxPosx),
            Mathf.Clamp(player.position.y+ maxCamera, minPosY, maxPosY),transform.position.z);

        transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
    }
}
