using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primeraPersona : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] nodos;
    public float velocidad = 5f;
    private int indice = 0;
    public float distanciaEntre = 0.1f;
    public Camera cam;
    public Transform cabeza;

    void Start()
    {
        this.transform.position = nodos[indice].transform.position;
        cam.transform.position = cabeza.position;
        transform.LookAt(nodos[indice].transform);
        cam.transform.LookAt(nodos[indice+1].transform);
        indice++;
    }

    // Update is called once per frame
    void Update()
    {
        if (indice >= nodos.Length)
        {
            // mostrar pantalla de llegada
            indice = 0;
            this.transform.position = nodos[indice].transform.position;
            cam.transform.position = cabeza.position;
            transform.LookAt(nodos[indice].transform);
            cam.transform.LookAt(nodos[indice + 1].transform);
            indice++;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, nodos[indice].transform.position, velocidad * Time.deltaTime);
        cam.transform.position = cabeza.position;
        if (Vector3.Distance(this.transform.position, nodos[indice].transform.position) < distanciaEntre)
        {
            indice++;
            transform.LookAt(nodos[indice].transform);
            cam.transform.LookAt(nodos[indice].transform);
        }
        
    }
}
