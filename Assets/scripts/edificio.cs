using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class edificio : MonoBehaviour
{
    public string nombre;
    public int capacidad;
    public List<GameObject> entradas;
    public GameObject techo;
    private Color normal = Color.red;
    private Color seleccionado = Color.green;
    public Material Mnormal;
    public Material Mselec;
    public Material miMaterial;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Capacidad { get => capacidad; set => capacidad = value; }
    public List<GameObject> Entradas { get => entradas; set => entradas = value; }
   
    // Start is called before the first frame update
    void Start()
    {
        entradas = new List<GameObject>();
        desmarcarEdificio();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public edificio(string nombre, int capacidad, List<GameObject> entradas)
    {
        this.Nombre = nombre;
        this.capacidad = capacidad;
        this.entradas = entradas;
    }

    public void fijarEdificio()
    {
        miMaterial = Mselec;
    }

    public void desmarcarEdificio()
    {
        //renderer.material.color = normal;
        miMaterial = Mnormal;
        //gameObject.GetComponent<MeshRenderer>().materials[0].color = normal;
    }


}
