using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movxd : MonoBehaviour
{
    public float Speed = 0.1f;
    public Joystick joystick;
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -20f;
    public float maxZ = 20f;

    public GameObject originalPos;
    void Update()
    {
        float xAxisValue = joystick.Horizontal * Speed ;
        float zAxisValue = joystick.Vertical * Speed ;
        float yValue = 0.0f;

        if (Input.GetKey(KeyCode.Q))
        {
            yValue = -Speed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            yValue = Speed;
        }

        if(transform.position.x < minX)
        {
            transform.position = new Vector3(-10f, transform.position.y + yValue, transform.position.z + zAxisValue);
        }

        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(10f, transform.position.y + yValue, transform.position.z + zAxisValue);
        }
        
        if (transform.position.z < minZ)
        {
            transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + yValue,minZ);
        }

        if (transform.position.z > maxZ)
        {
            transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + yValue, maxZ);
        }
        



        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + yValue, transform.position.z + zAxisValue);
    }

    public void resetearPos()
    {
        transform.SetPositionAndRotation(originalPos.transform.position, originalPos.transform.rotation);
    }
}