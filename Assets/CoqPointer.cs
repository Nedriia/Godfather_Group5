using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoqPointer : MonoBehaviour
{
    public Transform poule;
    public Transform coq;

    // Update is called once per frame
    void Update()
    {
        transform.position = poule.position + Vector3.up * 12;
        transform.GetChild(0).LookAt(coq.position , Vector3.up);
        GetComponentInChildren<TextMesh>().text = Mathf.RoundToInt((coq.position - poule.position).magnitude / 10).ToString() + "m";
    }
}
