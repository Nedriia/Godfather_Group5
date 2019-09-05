using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winlose : MonoBehaviour
{
    public GameObject _Win;
    public GameObject _Lose;
    public GameObject _poule;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > _poule.transform.position.x)
        {
            _Win.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider collision) {
        /*if (collision.gameObject.CompareTag("player"))
        {
            _Win.SetActive(true);
            Time.timeScale = 0;
        }*/
                if (collision.gameObject.CompareTag("finish"))
            _Lose.SetActive(true);
        Time.timeScale = 0;
    } }
