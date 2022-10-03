using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class edificioUIScript : MonoBehaviour
{
    private edificio edificio;
    public GameObject ui;
    public TextMeshProUGUI texto;
    public GameObject panel;

    private void Start()
    {
        
    }

    public void Update()
    {
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

        this.edificio = ed;

        transform.position = edificio.techo.transform.position;
        edificio.fijarEdificio();
        //pokemon poke = pokeApi.darPokemon();
        string respuesta = ed.numero + "-" +ed.nombre;
        texto.text = respuesta;
        ui.SetActive(true);
    }

    public void hide()
    {
        ui.SetActive(false);
        edificio.desmarcarEdificio();
    }

    public edificio GetEdificio()
    {
        return this.edificio;
    }

}
