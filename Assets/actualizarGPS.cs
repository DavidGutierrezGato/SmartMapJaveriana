using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actualizarGPS : MonoBehaviour
{
    public Text coordenadas;

    // Update is called once per frame
    void Update()
    {
        coordenadas.text = "Lat: " + geolocalizacion.Instance.latitud.ToString() + " \n Long: " + geolocalizacion.Instance.longitud.ToString(); 
    }
}
