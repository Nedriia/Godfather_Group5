using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_car : MonoBehaviour
{
    public GameObject[] allCars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject car in allCars)
            {
                car.GetComponent<car_move_colider>().ismove = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
