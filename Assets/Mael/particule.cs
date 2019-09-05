using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particule : MonoBehaviour
{
    private ParticleSystem pr;
    private Vector3 contact;
    public GameObject Particule;

    // Start is called before the first frame update
    void Start()
    {
        pr = Particule.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
      //  if (collision.gameObject.CompareTag("Platform"))
            contact = collision.contacts[0].point;
        Particule.transform.position = contact;
        pr.Play();
    }
   
}
