using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_aile : MonoBehaviour
{

    public float speed_rotation = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,speed_rotation,0);
    }
}
