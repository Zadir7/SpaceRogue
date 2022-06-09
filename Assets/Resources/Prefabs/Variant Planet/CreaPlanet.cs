using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaPlanet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SearchFirstObject firstObject = new SearchFirstObject();
        firstObject.SearchFirstObjectOnTag(gameObject.transform.position, "Star");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
