using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throw_rock : MonoBehaviour
{

    public bool isThrow;
    public float forceX;
    public float forceY;
    public float forceZ;
    public float forceChute;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrow)
        {
            GetComponent<Rigidbody>().AddRelativeForce(forceX, forceY, forceZ);
            isThrow = false;
        }
        GetComponent<Rigidbody>().AddForce(0, forceChute, 0);
    }
}
