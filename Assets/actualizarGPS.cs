using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actualizarGPS : MonoBehaviour
{
    public Text coordenadas;
    public geolocalizacion geo;
    public Transform persona;

    // Update is called once per frame
    void Update()
    {
        coordenadas.text = " Long: " + geo.getLongitudX().ToString() + "\nLat: " + geo.getLatitudY().ToString();
        if(geo.getLongitudX() < 550 && geo.getLongitudX() > -270 &&
            geo.getLatitudY() < 700 && geo.getLatitudY() > -100)
        {
            persona.gameObject.SetActive(true);
            persona.position = new Vector3((float)geo.getLongitudX(), persona.position.y, (float)geo.getLatitudY());
        }
        else
        {
            // Debug.Log("no esta en la universidad");
            persona.gameObject.SetActive(false);
        }
        
    }
}
