using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move_colider : MonoBehaviour
{

    // Vitesse
    public float speedCar;
    public float force;
    public bool ismove;
    public float force_chute = -50f;
    bool isTouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Plane")
        {
            isTouch = true;
            GetComponent<Rigidbody>().AddExplosionForce(force , collision.contacts[0].point , 200, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ismove) GetComponent<Rigidbody>().AddForce(transform.forward * speedCar);
        GetComponent<Rigidbody>().AddForce(0, force_chute, 0);
    }
}
