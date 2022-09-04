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

   

    

    public void setEdificio(edificio ed)
    {

        this.edificio = ed;

        transform.position = edificio.techo.transform.position;
        edificio.fijarEdificio();
        pokemon poke = pokeApi.darPokemon();
        texto.text = poke.value;
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
