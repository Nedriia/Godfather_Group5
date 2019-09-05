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
    Rigidbody car;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            car.isKinematic = false;
            car.AddExplosionForce(force, collision.contacts[0].point, 200, 0.0f);
        }
        else if (collision.gameObject.name != "Plane" && ismove )
        {
            car.AddExplosionForce(force , collision.contacts[0].point , 200, 0.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ismove)
        {
            car.isKinematic = false;
            car.AddForce(transform.forward * speedCar);
        }
        car.AddForce(0, force_chute, 0);
    }
}
