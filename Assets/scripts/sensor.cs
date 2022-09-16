using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sensor : MonoBehaviour
{

    public float radio;
    public LayerMask capa;
    public GameObject masCercano;

    private void Start()
    {
        Debug.Log("comparando");
        Collider[] colliders = Physics.OverlapSphere(transform.position, radio, capa);
        Array.Sort(colliders, new comparadorDistancias(transform));

        //masCercano = colliders[0].GetComponent<GameObject>();
        foreach(Collider collider in colliders)
        {
            Debug.Log(collider.name);
        }
        if(colliders.Length > 0)
        {
            masCercano = colliders[0].gameObject;
        }
        
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
