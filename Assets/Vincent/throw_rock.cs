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

    Rigidbody rock;

    // Start is called before the first frame update
    void Start()
    {
        rock = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrow)
        {
            rock.isKinematic = false;
            rock.AddRelativeForce(forceX, forceY, forceZ);
            isThrow = false;
        }
        rock.AddForce(0, forceChute, 0);
    }
}
