using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    public float Delay;

    void Start()
    {

        StartCoroutine(StartDelay());

    }

    IEnumerator StartDelay()
    {

        yield return new WaitForSeconds(Delay);
        Destroy(gameObject);

    }

}