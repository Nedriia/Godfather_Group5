using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_rock : MonoBehaviour
{
    public GameObject[] allRock;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject rock in allRock)
            {
                rock.GetComponent<throw_rock>().isThrow = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
