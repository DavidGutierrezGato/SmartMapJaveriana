using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoricoPos : MonoBehaviour
{
    public sensor sensor;
    public UnityAndroid UnityAndroid;

    private string nodoAnterior;
    private string nodoActual;

    // Start is called before the first frame update
    void Start()
    {
        nodoActual = sensor.masCercano.name;
        nodoAnterior = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(nodoActual != sensor.masCercano.name )
        {
            nodoAnterior = nodoActual;
            nodoActual = sensor.masCercano.name;
            string param = nodoAnterior + "," + nodoActual;
            UnityAndroid.actualizarPosicion(param);
        }
        
    }
}
