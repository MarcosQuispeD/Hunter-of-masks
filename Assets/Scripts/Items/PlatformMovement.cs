using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public Transform pos_1, pos_2;
    public float speed;
    public Transform startPosition;

    Vector3 nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = startPosition.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position == pos_1.position)
        {
            nextPosition = pos_2.position;
        }
        if (transform.position == pos_2.position)
        {
            nextPosition = pos_1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position,nextPosition,speed*Time.deltaTime);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos_1.position,pos_2.position);
    }

}
