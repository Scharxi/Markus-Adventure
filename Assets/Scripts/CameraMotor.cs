using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
    }


    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // get the distance between the camera and the player
        float deltaX = lookAt.position.x - transform.position.x;

        // check if the player leaves the camera bounds on the X Axis
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // get the distance between the camera and the player
        float deltaY = lookAt.position.y - transform.position.y;

        // check if the player leaves the camera bounds on the X Axis
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        // move the camera
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}