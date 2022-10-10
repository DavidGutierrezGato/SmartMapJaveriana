using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class edificio : MonoBehaviour
{
    public string nombre;
    public int capacidad;
    public int numero;
    public List<GameObject> entradas;
    public GameObject techo;
    //public GameObject particulaSeleccion;
    

    public string Nombre { get => nombre; set => nombre = value; }
    public int Capacidad { get => capacidad; set => capacidad = value; }

    public int Numero { get => numero; set => numero = value; }
    public List<GameObject> Entradas { get => entradas; set => entradas = value; }
   
    // Start is called before the first frame update
    void Start()
    {
        //entradas = new List<GameObject>();
        desmarcarEdificio();
        
        techo.transform.position = new Vector3(techo.transform.position.x, techo.transform.position.y+13, techo.transform.position.z);
        //particulaSeleccion.transform.position = new Vector3(techo.transform.position.x, techo.transform.position.y, techo.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public edificio(string nombre, int capacidad, List<GameObject> entradas, int numero)
    {
        this.Nombre = nombre;
        this.capacidad = capacidad;
        this.entradas = entradas;
        this.numero = numero;
    }

    public void fijarEdificio()
    {
      
    }

    public void desmarcarEdificio()
    {
        //renderer.material.color = normal;
       // miMaterial = Mnormal;
        //gameObject.GetComponent<MeshRenderer>().materials[0].color = normal;
    }


}
