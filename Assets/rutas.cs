using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rutas : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> nodos;
    public float velocidad = 5f;
    private int indice = 0;
    public float distanciaEntre = 0.1f;
    public bool empezo = false;
    public GameObject linea;
    public GameObject canvasCancelar;
    public GameObject canvasFinRuta;
    public GameObject botonCancelar;
    public sensor sensor;

    //modificado
    private string nodoCercano;
    public PlayerInput input;
    public UnityAndroid controladorUnity;


    void Start()
    {
        //this.transform.position = nodos[indice].transform.position;
        //indice++;
        canvasCancelar.SetActive(false);
        botonCancelar.SetActive(false);
        canvasFinRuta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //modificado
        nodoCercano = sensor.masCercano.name;

        if(empezo)
        {
            // Modificado
            if(nodoCercano != nodos[0].name)
            {
                // cambiar a calcular ruta unity (unityAndroid.cs)
                //input.btnFindPath(sensor.masCercano.transform, nodos[nodos.Count - 1].transform);
                controladorUnity.CalcularRutaUnityActualizado();
            }

            //this.transform.position = Vector3.MoveTowards(this.transform.position, nodos[indice].transform.position, velocidad * Time.deltaTime);

            /*if (Vector3.Distance(this.transform.position, nodos[indice].transform.position) < distanciaEntre)
            {
                indice++;
            }
            */
            if (sensor.masCercano.name == nodos[nodos.Count - 1].name)
            {
                // mostrar pantalla de llegada
                indice = 0;
                empezo = false;
                linea.SetActive(false);
                pararRuta();
                mostrarMensajeLlegada();

            }
           
        }
        
    }

    // funcion original
    /*
    public void empezarRuta(List<GameObject> pnodos)
    {
        this.nodos = pnodos;
        this.transform.position = nodos[indice].transform.position;
        indice++;
        empezo = true;
        linea.SetActive(true);
        botonCancelar.SetActive(true);
        foreach(GameObject p in pnodos)
        {
            Debug.LogError(p.name);
        }


    }
    */

    // funcion modificada
    public void empezarRuta(List<GameObject> pnodos, Boolean basico)
    {
        this.nodos = pnodos;
        //this.transform.position = nodos[indice].transform.position;
        //indice++;
        empezo = true;
        linea.SetActive(true);
        if (basico)
        {
            linea.GetComponent<LineRenderer>().startColor = Color.red;
        }
        else
        {
            linea.GetComponent<LineRenderer>().startColor = Color.cyan;
        }
        
        botonCancelar.SetActive(true);
        foreach (GameObject p in pnodos)
        {
            Debug.LogError(p.name);
        }


    }

    public void pararRuta()
    {
        indice = 0;
        empezo = false;
        linea.SetActive(false);
        canvasCancelar.SetActive(false);
        botonCancelar.SetActive(false);
    }

    public void cancelarRuta()
    {
        canvasCancelar.SetActive(true);
    }

    public void cancelarRutaNo()
    {
        canvasCancelar.SetActive(false);
    }

    public void cancelarRutaSi()
    {
        canvasCancelar.SetActive(false);
        pararRuta();
    }

    public void mostrarMensajeLlegada()
    {
        canvasFinRuta.SetActive(true);
    }

    public void quitarMensajeLlegada()
    {
        canvasFinRuta.SetActive(false);
    }

}
