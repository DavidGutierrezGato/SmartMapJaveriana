using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rutas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] nodos;
    public float velocidad = 5f;
    private int indice = 0;
    public float distanciaEntre = 0.1f;

    void Start()
    {
        this.transform.position = nodos[indice].transform.position;
        indice++;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, nodos[indice].transform.position, velocidad * Time.deltaTime);

        if (Vector3.Distance(this.transform.position, nodos[indice].transform.position) < distanciaEntre)
        {
            indice++;
        }
        if(indice >= nodos.Length)
        {
            // mostrar pantalla de llegada
            indice = 0;
        }
    }
}
