using System.Collections;
using System.Collections.Generic;
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
        if(Vector3.Distance(inicio.transform.position, destino.transform.position) < 10f)
        {
            //ruta.Add(destino);
            return;
        }

        List<GameObject> vecinosNodo = inicio.GetComponent<nodo>().vecinos;
        float distanciaMinima = 1000000f;
        GameObject ganador = null;
        foreach (GameObject veci in vecinosNodo)
        {
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
    public void calcularRutaBasica()
    {
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
        rutas.empezarRuta(ruta);

    }

}