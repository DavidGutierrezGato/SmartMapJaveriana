using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actualizarGPS : MonoBehaviour
{
    public Text coordenadas;
    public geolocalizacion geo;
    public Transform persona;
    public Transform cuerpo;

    // Update is called once per frame
    void Update()
    {
        
        coordenadas.text = " Long: " + geo.getLongitudX().ToString() + "\nLat: " + geo.getLatitudY().ToString();
        if(geo.getLongitudX() < 550 && geo.getLongitudX() > -270 &&
            geo.getLatitudY() < 700 && geo.getLatitudY() > -100)
        {
            persona.gameObject.SetActive(true);
            persona.position = new Vector3((float)geo.getLongitudX()+10, persona.position.y, (float)geo.getLatitudY()+5);

            cuerpo.gameObject.SetActive(true);
            cuerpo.position = new Vector3((float)geo.getLongitudX(), cuerpo.position.y, (float)geo.getLatitudY());
        }
        else
        {
            // Debug.Log("no esta en la universidad");
            persona.gameObject.SetActive(false);
            cuerpo.gameObject.SetActive(false);
        }
        
    }
}
