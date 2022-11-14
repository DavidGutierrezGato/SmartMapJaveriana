using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class rutaBasica : MonoBehaviour
{
    // Start is called before the first frame update
    public sensor sensor;
    public GameObject destino;
    public rutas rutas;
    public GameObject linea;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void calcularRutaBasicaR(List<GameObject> ruta,GameObject inicio, GameObject destino)
    {
        if(Vector3.Distance(inicio.transform.position, destino.transform.position) < 10f || 
                inicio.name == destino.name)
        {
            //ruta.Add(destino);
            return;
        }

        List<GameObject> vecinosNodo = inicio.GetComponent<nodo>().vecinos;
        float distanciaMinima = 100000000000f;
        GameObject ganador = null;
        foreach (GameObject veci in vecinosNodo)
        {
           //if (ruta.Contains(veci) && vecinosNodo.Count == 1)
            //{
            //    ruta.Remove(inicio);
            //    ganador = ruta[ruta.Count-1];
            //}

            if(!ruta.Contains(veci))
            {
                if (Vector3.Distance(veci.transform.position, destino.transform.position) < distanciaMinima)
                {
                    distanciaMinima = Vector3.Distance(veci.transform.position, destino.transform.position);
                    ganador = veci;
                }
            }
            
        }
        ruta.Add(ganador);

        calcularRutaBasicaR(ruta, ganador, destino);


    }
    public void calcularRutaBasica(GameObject des)
    {
        destino = des;
        GameObject inicio = sensor.masCercano;
        List<GameObject> ruta = new List<GameObject>();
        List<GameObject> visitados = new List<GameObject>();
        ruta.Add(inicio);
        visitados.Add(inicio);
        List<GameObject> vecinosNodo = inicio.GetComponent<nodo>().vecinos;
        float distanciaMinima = 100000000000f;
        GameObject ganador = null;
        foreach (GameObject veci in vecinosNodo)
        {
            if(Vector3.Distance(veci.transform.position, destino.transform.position) < distanciaMinima)
            {
                distanciaMinima = Vector3.Distance(veci.transform.position, destino.transform.position);
                ganador = veci;
            }
        }
        ruta.Add(ganador);

        calcularRutaBasicaR(ruta, ganador, destino);

        foreach(GameObject nodo in ruta)
        {
            Debug.LogError(nodo.name);
        }

        linea.GetComponent<nodo>().vecinos = ruta;
        linea.GetComponent<nodo>().pintarRuta();
        rutas.empezarRuta(ruta,true);

    }

    public void calcularRutaBasica2(GameObject des)
    {

        
    }

    public void calcularRutaBasica(GameObject ini,GameObject des)
    {
        destino = des;
        GameObject inicio = ini;
        List<GameObject> ruta = new List<GameObject>();
        List<GameObject> visitados = new List<GameObject>();
        ruta.Add(inicio);
        visitados.Add(inicio);
        List<GameObject> vecinosNodo = inicio.GetComponent<nodo>().vecinos;
        float distanciaMinima = 100000000000f;
        GameObject ganador = null;
        foreach (GameObject veci in vecinosNodo)
        {
            if (Vector3.Distance(veci.transform.position, destino.transform.position) < distanciaMinima)
            {
                distanciaMinima = Vector3.Distance(veci.transform.position, destino.transform.position);
                ganador = veci;
            }
        }
        ruta.Add(ganador);

        calcularRutaBasicaR(ruta, ganador, destino);

        foreach (GameObject nodo in ruta)
        {
            Debug.LogError(nodo.name);
        }

        linea.GetComponent<nodo>().vecinos = ruta;
        linea.GetComponent<nodo>().pintarRuta();
        rutas.empezarRuta(ruta, true);

    }

}
