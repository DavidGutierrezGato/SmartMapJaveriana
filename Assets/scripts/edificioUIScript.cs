using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class edificioUIScript : MonoBehaviour
{
    private edificio edificio;
    public GameObject ui;
    public TextMeshProUGUI texto;
    public GameObject panel;
    public GameObject particulaSeleccion;
    public rutas rutas;
    public float desface = 0;

    private void Start()
    {
        
    }

    public void Update()
    {
        /*if(Vector3.Distance(Camera.main.transform.position,transform.position) < 20)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
        */

        panel.transform.LookAt(Camera.main.transform.position) ;
        panel.transform.eulerAngles = new Vector3(
         panel.transform.eulerAngles.x,
         panel.transform.eulerAngles.y + 180,
         panel.transform.eulerAngles.z
        );


        //ui.transform.rotation = new Quaternion(0, 0, 0, 90);
    }


    public void setEdificio(edificio ed)
    {

        if(!rutas.empezo)
        {
            this.edificio = ed;

            transform.position = edificio.techo.transform.position + new Vector3(0,10, -50);
            particulaSeleccion.transform.position = edificio.techo.transform.position;

            particulaSeleccion.transform.Translate(new Vector3(0, 0, 20));




            edificio.fijarEdificio();
            //pokemon poke = pokeApi.darPokemon();
            string respuesta = ed.numero + "-" + ed.nombre;
            texto.text = respuesta;
            ui.SetActive(true);
            particulaSeleccion.SetActive(true);
        }
        
    }

    public void hide()
    {
        ui.SetActive(false);
        particulaSeleccion.SetActive(false);
        edificio.desmarcarEdificio();
    }

    public edificio GetEdificio()
    {
        return this.edificio;
    }

}
