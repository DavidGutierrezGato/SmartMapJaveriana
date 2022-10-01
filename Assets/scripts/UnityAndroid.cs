using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnityAndroid : MonoBehaviour
{
    public TextMeshProUGUI text;
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

        unityPlayerActivity.Call("informacionEdificioAndroid", numeroEdificio);
    }

        //Calcular Ruta
    /*
     * Enviar edificio destino y el nodo mas cercano a la persona
     * Si NO est� en la universidad o quiere indicar otro punto de partida,
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


        string parametros = "pruebaaaa";
        unityPlayerActivity.Call("informacionEdificioAndroid",parametros );

    }




     // Recibir Ruta
    // recibir string y trazar la ruta dependiendo del tipo de ruta
    /*
     * (Tipo,nodoInicio,Lista ruta) � (Tipo,NombreEd,NombreEd) ? caso especial
    �B�sico-5,14,28,64,10,3�
    �B�sico-Bar�n,Giraldo�? caso especial
    �Completo-5,14,28,64,10,3�
    */


    public void RecibirRutaUnity(string respuesta)
    {
        Debug.Log(respuesta);
    }

}