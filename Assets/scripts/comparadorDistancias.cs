using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comparadorDistancias : IComparer
{
    private Transform transformAComparar;


    public comparadorDistancias(Transform transformAComparar)
    {
        this.transformAComparar = transformAComparar;
    }

    public int Compare(object x, object y)
    {
        Collider colliderX = x as Collider;
        Collider colliderY = y as Collider;

        Vector3 offset = colliderX.transform.position - transformAComparar.transform.position;
        float distanciaX = offset.sqrMagnitude;

        offset = colliderY.transform.position - transformAComparar.transform.position;
        float distanciaY = offset.sqrMagnitude;

        return distanciaX.CompareTo(distanciaY);
    }
}
