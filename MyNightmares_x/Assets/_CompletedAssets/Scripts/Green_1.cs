using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("De", 1);
    }
    void De()
    {
        DestroyImmediate(this.gameObject, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
