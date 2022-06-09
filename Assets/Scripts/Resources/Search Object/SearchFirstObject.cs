using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchFirstObject
{
    public Vector3 SearchFirstObjectOnTag(Vector3 thisObject, string tag = "Star")
    {
        GameObject[] serchObject = GameObject.FindGameObjectsWithTag(tag);
        if (serchObject != null)
        {
            GameObject findObject = serchObject[0];
            float radiysOrbit = Mathf.Sqrt( (thisObject.x - serchObject[0].transform.position.x) * (thisObject.x - serchObject[0].transform.position.x)
                                            + (thisObject.y - serchObject[0].transform.position.y) * (thisObject.y - serchObject[0].transform.position.y));
            for (int i = 0; i < serchObject.Length; i++)
            {
            float searchOrbit = Mathf.Sqrt((thisObject.x - serchObject[i].transform.position.x) * (thisObject.x - serchObject[i].transform.position.x)
                                            + (thisObject.y - serchObject[i].transform.position.y) * (thisObject.y - serchObject[i].transform.position.y));
                if (searchOrbit < radiysOrbit)
                {
                    findObject = serchObject[i];
                    radiysOrbit = searchOrbit;
                }
            }
            return findObject.transform.position;
        }
        else
        {
        return Vector3.zero;
        }
    }
}
