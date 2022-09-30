using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class rutaAuto : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agente;
    public Transform transform;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agente.SetDestination(hit.point);
            }
        }
    }

    public void irAEdificio()
    {
        
        agente.SetDestination(transform.position);
    }

    public void irAEdificioString(string nombreEdificio)
    {

        agente.SetDestination(transform.position);
    }
}
