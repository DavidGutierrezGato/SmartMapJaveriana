using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actualizarGPS : MonoBehaviour
{
    public Text coordenadas;
    public geolocalizacion geo;

    // Update is called once per frame
    void Update()
    {
        coordenadas.text = " Long: " + geo.getLongitudX().ToString() + "\nLat: " + geo.getLatitudY().ToString(); 
    }
}
