using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class nodo : MonoBehaviour
{

    public List<GameObject> vecinos = new List<GameObject>();
    public LineRenderer lineRenderer;
    private int c = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void pintarRuta()
    {
        //lineRenderer = new LineRenderer();
        foreach (GameObject obj in vecinos)
        {
            //LineRenderer lineRenderer2 = new LineRenderer();
           
            lineRenderer.positionCount = vecinos.Count;

            //lineRenderer2.SetPosition(c, this.transform.position);
            lineRenderer.SetPosition(c, obj.transform.position);
            c++;

        }
        c = 0;
    }



}
