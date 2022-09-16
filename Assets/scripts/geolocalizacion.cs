using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class geolocalizacion : MonoBehaviour
{
    // Start is called before the first frame update
    
    //public static geolocalizacion Instance { set; get; }

    public decimal minimoLatY = 4.62653170926943M;
    public decimal minimoLongX = -74.0654885831475M;

    public decimal maximoLatY = 4.63116268860274M;
    public decimal maximoLongX = -74.0618383379272M;


    public decimal diffX;
    public decimal diffY;

    public decimal factorX;
    public decimal factorY;


    public decimal minimoMapaLat;
    public decimal minimoMapaLong;

    public decimal maximoMapaLat;
    public decimal maximoMapaLong;

    public decimal latitud = 4.62605184066525M;
    public decimal longitud = -74.0627447697475M;

    public decimal latitudMY;
    public decimal longitudMX;

    public int tiempoEspera = 50;

    void Start()
    {
        //Instance = this;
        //DontDestroyOnLoad(gameObject);
        // StartCoroutine(darUbicacion());


        diffX = maximoLongX - minimoLongX;
        diffY = maximoLatY - minimoLatY;

        factorX = 373 / diffX;
        factorY = 534/ diffY;

        //factorX = 102184.916;
        //factorY = 115310.383;

        latitudMY = (latitud - minimoLatY) * factorY;
        longitudMX = (longitud - minimoLongX) * factorX;


        Debug.Log("diffX: " + diffX + "  diffY: " + diffY);
        Debug.Log("factorX: " + factorX + "  factorY: " + factorY);
        Debug.Log("X: " + longitudMX + " Y: " + latitudMY);

    }

    private void Update()
    {
        //Debug.Log("entre");

        if (!Input.location.isEnabledByUser)
        {
           // Debug.Log("no habilito el GPS");
           
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




      //  latitud = Input.location.lastData.latitude;

      //  longitud = Input.location.lastData.longitude;

        //latitudMY = (latitud - minimoLatY) * factorY;
        //longitudMX = (longitud - minimoLongX) * factorX;

      //Debug.Log("X: " + longitudMX + " Y: " + latitudMY);

       

    }

    public decimal getLongitudX()
    {
        return this.longitudMX;
    }

    public decimal getLatitudY()
    {
        return this.latitudMY;
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
