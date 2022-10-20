using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class listarNodos : MonoBehaviour
{
    public List<GameObject> lista;
    public void generarTxt()
    {
        string texto = "";
        foreach (GameObject nodo in lista)
        {
            texto += nodo.name + "*" + nodo.transform.position.x + "*" + nodo.transform.position.z+"*1";
            List<GameObject> vecinos = new List<GameObject>();
            vecinos = nodo.GetComponent<nodo>().vecinos;
            if(vecinos.Count > 0)
            {
                texto += "*";
                for(int i = 0; i < vecinos.Count; i++)
                {
                    if(i == vecinos.Count -1)
                    {
                        texto += vecinos[i].name;
                    }
                    else
                    {
                        texto += vecinos[i].name + "-";
                    }
                    
                }
            }
            texto += "_\n";
        }

        string path = Application.dataPath + "/nodos.txt";
        File.WriteAllText(path, texto);
    }

}
