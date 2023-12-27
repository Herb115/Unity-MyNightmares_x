using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationEffect : MonoBehaviour
{
    public GameObject gb;
    public GameObject gm;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    public void AE()
    {
        GameObject objB = Instantiate(gb, transform);
    }
    public void AM()
    {
        GameObject objM = Instantiate(gm, transform);

    }
   
    // Update is called once per frame
    void Update()
    {

    }
}
