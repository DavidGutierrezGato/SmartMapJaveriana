using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnityAndroid : MonoBehaviour
{
    public TextMeshProUGUI text;
    public rutaBasica ruta;
    public sensor sensor;
    public PlayerInput mejorRuta;
    public string obtenerEdificioSeleccionado()
    {
        string nombre = null;

        nombre = text.text;

        return nombre;
    }


    // Ver mas informacion de X edificio
    // Enviar nombre de edificio
    public void InformacionEdificioUnity()
    {
        // obtener edificio seleccionado

        string numeroEdificio = obtenerEdificioSeleccionado();
        string[] partes = numeroEdificio.Split("-");
        numeroEdificio = partes[0];
        Debug.LogError(numeroEdificio);
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityPlayerActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        unityPlayerActivity.CallStatic("informacionEdificioAndroid", numeroEdificio);
    }

        //Calcular Ruta
    /*
     * Enviar edificio destino y el nodo mas cercano a la persona
     * Si NO está en la universidad o quiere indicar otro punto de partida,
     * la persona debe buscar el edificio desde el cual quiere iniciar la ruta (Android)
     * 
     */
    public void CalcularRutaUnity()
    {
        // obtener edificio seleccionado
        // obtener nodo mas cercano
        // si es null, android preguntara desde donde calcular la ruta
        
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityPlayerActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        
        string numeroEdificio = obtenerEdificioSeleccionado();
        string[] partes = numeroEdificio.Split("-");
        numeroEdificio = partes[0];
        string parametros = "";


        GameObject inicio = sensor.masCercano;
        if(inicio != null)
        {
            string[] partes2;
            partes2 = inicio.name.Split(" (");
            string[] final = partes2[1].Split(")");
            // nodo (25)
            // nodo
            parametros = final[0] +numeroEdificio;
        }
        else
        {
            parametros = "null,"+numeroEdificio;
        }

        

        //GameObject destino = GameObject.Find("ED-" + numeroEdificio);
        //GameObject destino2 = destino.GetComponent<edificio>().entradas[0];
        //ruta.calcularRutaBasica(destino2);
        
        unityPlayerActivity.CallStatic("calcularRutaAndroid",parametros );



    }




     // Recibir Ruta
    // recibir string y trazar la ruta dependiendo del tipo de ruta
    /*
     * (Tipo,nodoInicio,Lista ruta) ó (Tipo,NombreEd,NombreEd) ? caso especial
    “Básico-5,14,28,64,10,3”
    “Básico-Barón,Giraldo”? caso especial
    “Completo-5,14,28,64,10,3”
    */


    public void RecibirRutaUnity(string respuesta)
    {
        //“Básico-5-ED-25”
        //“Completo-5-14,28,64,10,3”
        //Básico-ED-67-ED-25

        string[] partes = respuesta.Split("-");

        if (partes[0] == "Basico")
        {
            if (partes.Length ==5)
            {
                GameObject inicio = GameObject.Find("ED-" + partes[2]);
                GameObject inicio2 = inicio.GetComponent<edificio>().entradas[0];

                GameObject destino = GameObject.Find("ED-" + partes[4]);
                GameObject destino2 = destino.GetComponent<edificio>().entradas[0];

                //ruta.calcularRutaBasica(inicio2, destino2);
                //--------------------- cambiar en vez de ruta, al player input
                mejorRuta.btnFindPath(inicio2.transform, destino2.transform);
            }

            if (partes.Length == 4)
            {
                GameObject inicio = GameObject.Find("nodo (" + partes[1]+")");
                //GameObject inicio2 = inicio.GetComponent<edificio>().entradas[0];

                GameObject destino = GameObject.Find("ED-" + partes[3]);
                GameObject destino2 = destino.GetComponent<edificio>().entradas[0];

                //ruta.calcularRutaBasica(inicio, destino2);
                mejorRuta.btnFindPath(inicio.transform, destino2.transform);
            }


        }
        else
        {

        }
        
    }

}
