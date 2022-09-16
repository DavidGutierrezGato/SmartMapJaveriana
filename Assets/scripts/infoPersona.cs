using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoPersona : MonoBehaviour
{
    public GameObject nodoMasCercano;
    public sensor sensorMasCercano;
    // Start is called before the first frame update
    void Start()
    {
        nodoMasCercano = sensorMasCercano.masCercano;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
