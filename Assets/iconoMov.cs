using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class iconoMov : MonoBehaviour
{
    public float speed;
    public float height;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(this.transform.position, Vector3.up, 20 * Time.deltaTime);

        //Vector3 pos = transform.position;
        //calculate what the new Y position will be
        //float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        //transform.position = new Vector3(pos.x, newY, pos.z) * height;


    }
}
