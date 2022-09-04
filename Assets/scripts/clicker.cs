using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class clicker : MonoBehaviour
{
   
    public edificioUIScript edificioUI;
    private edificio seleccionado;

    // Start is called before the first frame update
    void Start()
    {
        //edificioUI.hide();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            print("dispare");
            if (Physics.Raycast(ray, out hit,500f))
            {
                print("pegue 22");
                if (hit.transform != null)
                {
                    print("pegue");
                    if (hit.transform.gameObject.CompareTag("edificio") == true)
                    {
                        
                        MostrarInfo(hit.transform.gameObject);
                        
                    }
                    else if (hit.transform.gameObject.CompareTag("ui") == true)
                    {

                        //edificioUI.hide();

                    }
                    else
                    {
                        //edificioUI.hide();
                    }
                    
                }
                else
                {
                    //edificioUI.hide();
                }
            }
            else
            {
                print(" ASDASDASDS 22");
                //edificioUI.hide();
            }
        }
            

    }

    private void MostrarInfo(GameObject ob)
    {
        print(ob.name);
        edificio [] edificios =  FindObjectsOfType<edificio>();
        foreach (edificio edificio in edificios)
        {
            if (edificio.gameObject.name.Equals( ob.name))
            {
                string info = edificio.Nombre + edificio.Capacidad.ToString();
                print(info);

                // mostrar informacion en pantalla
                


                edificioUI.setEdificio(edificio);

            }
        }
    }
}
