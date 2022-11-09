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
    public Camera cam;
    public edificioUIScript edificioUI;
    public geolocalizacion geo;

    //modificado
    private string ultimoEdificio;

    public void Start()
    {
        ultimoEdificio = null;
    }

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
        
        
        
        string numeroEdificio = obtenerEdificioSeleccionado();
        if(numeroEdificio != ultimoEdificio )
        {
            ultimoEdificio = numeroEdificio;
        }
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
            parametros = final[0] + "-"+numeroEdificio;
        }
        else
        {
            parametros = "null-"+numeroEdificio;
        }

        print(parametros);
        Debug.LogError(parametros);

        //GameObject destino = GameObject.Find("ED-" + numeroEdificio);
        //GameObject destino2 = destino.GetComponent<edificio>().entradas[0];
        //ruta.calcularRutaBasica(destino2);
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityPlayerActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        unityPlayerActivity.CallStatic("calcularRutaAndroid",parametros );



    }

    public void CalcularRutaUnityActualizado()
    {
        // obtener edificio seleccionado
        // obtener nodo mas cercano
        // si es null, android preguntara desde donde calcular la ruta



        string numeroEdificio = ultimoEdificio;
        
        string[] partes = numeroEdificio.Split("-");
        numeroEdificio = partes[0];
        string parametros = "";


        GameObject inicio = sensor.masCercano;
        if (inicio != null)
        {
            string[] partes2;
            partes2 = inicio.name.Split(" (");
            string[] final = partes2[1].Split(")");
            // nodo (25)
            // nodo
            parametros = final[0] + "-" + numeroEdificio;
        }
        else
        {
            parametros = "null-" + numeroEdificio;
        }

        print(parametros);
        Debug.LogError(parametros);

        //GameObject destino = GameObject.Find("ED-" + numeroEdificio);
        //GameObject destino2 = destino.GetComponent<edificio>().entradas[0];
        //ruta.calcularRutaBasica(destino2);
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityPlayerActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        unityPlayerActivity.CallStatic("calcularRutaAndroid", parametros);



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


    // RECIBO EL NUMERO DEL EDIFICIO 
    // 55
    // 3
    public void RecibirEdificioAMostrar(string numEdi)
    {
        // obtener edificio
        
        GameObject[] partes = GameObject.FindGameObjectsWithTag("edificio");
        edificio actual = null;
        for (int i = 0; i < partes.Length; i++)
        {
            if(partes[i].name == "ED-"+ numEdi)
            {
                actual = partes[i].GetComponent<edificio>();
                break;
            }
        }

        // resetear camara
        cam.GetComponent<movxd>().resetearPos();

        // seleccionar edificio
        cam.transform.LookAt(actual.transform);
        edificioUI.setEdificio(actual);



    }


    // le paso un string con la latitud y longitud de android
    // Toca manejar muchos decimales
    // -7.654654321,45.321654654
    public void enviarPosicionActual()
    {
        string parametro = "";
        parametro += geo.latitud.ToString() +","+geo.longitud.ToString();
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityPlayerActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        unityPlayerActivity.CallStatic("recibirPosicionActual",parametro);
        Debug.LogError(parametro);

    }

    // le paso un string con el nodo anterior y el nodo actual
    // null,nodo (51)
    // null,null --> no deberia mandar nada
    // nodo (11),nodo (54)
    // nodo (11),null 
    public void actualizarPosicion(string parametros)
    {
        
        
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityPlayerActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

        unityPlayerActivity.CallStatic("actualizarPosicionAndroid", parametros);

    }

    public void centrarCamara()
    {
        cam.GetComponent<movxd>().resetearPos();

    }



}
