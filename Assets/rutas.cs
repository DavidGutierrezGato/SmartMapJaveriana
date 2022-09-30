using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rutas : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> nodos;
    public float velocidad = 5f;
    private int indice = 0;
    public float distanciaEntre = 0.1f;
    public bool empezo = false;
    public GameObject linea;
     

    void Start()
    {
        //this.transform.position = nodos[indice].transform.position;
        //indice++;
    }

    // Update is called once per frame
    void Update()
    {
        if(empezo)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, nodos[indice].transform.position, velocidad * Time.deltaTime);

            if (Vector3.Distance(this.transform.position, nodos[indice].transform.position) < distanciaEntre)
            {
                indice++;
            }
            if (indice >= nodos.Count)
            {
                // mostrar pantalla de llegada
                indice = 0;
                empezo = false;
                linea.SetActive(false);

            }
        }
        
    }

    public void empezarRuta(List<GameObject> pnodos)
    {
        this.nodos = pnodos;
        this.transform.position = nodos[indice].transform.position;
        indice++;
        empezo = true;
        linea.SetActive(true);
        
    }
}
