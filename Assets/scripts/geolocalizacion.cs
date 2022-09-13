using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class geolocalizacion : MonoBehaviour
{
    // Start is called before the first frame update

    public static geolocalizacion Instance { set; get; }

    private float minimoLat = 4.631278950873927f;
    private float minimoLong = -74.06410894791222f;

    float maximoLat = 4.625898481742873f;
    float maximoLong = -74.06247035270383f;

    public float minimoMapaLat;
    public float minimoMapaLong;

    public float maximoMapaLat;
    public float maximoMapaLong;

    public float latitud;
    public float longitud;

    public int tiempoEspera = 50;

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
       // StartCoroutine(darUbicacion());
    }

    private void Update()
    {
        Debug.Log("entre");

        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("no habilito el GPS");
           
        }

        Input.location.Start();

        while (Input.location.status == LocationServiceStatus.Initializing && tiempoEspera > 0)
        {
            //return new WaitForSeconds(1);
            tiempoEspera--;
        }

        if (tiempoEspera <= 0)
        {
            Debug.Log("Se acabo el tiempo");
             
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("No se pudo obtener la ubicacion");
           
        }




        latitud = Input.location.lastData.latitude;

        longitud = Input.location.lastData.longitude;


        Debug.Log("Lat: " + latitud + " Long: " + longitud);

       

    }

}

    /*

    private IEnumerator darUbicacion()
    {
        Debug.Log("entre");

        if(!Input.location.isEnabledByUser)
        {
            Debug.Log("no habilito el GPS");
            yield break;
        }

        Input.location.Start();
        
        while(Input.location.status == LocationServiceStatus.Initializing && tiempoEspera > 0)
        {
            yield return new WaitForSeconds(1);
            tiempoEspera--;
        }

        if(tiempoEspera <= 0)
        {
            Debug.Log("Se acabo el tiempo");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("No se pudo obtener la ubicacion");
            yield break;
        }


             
        
        latitud = Input.location.lastData.latitude;
        
        longitud = Input.location.lastData.longitude;


        Debug.Log("Lat: " + latitud + " Long: " + longitud);

        yield break;
        
    }
    */
   
//}
