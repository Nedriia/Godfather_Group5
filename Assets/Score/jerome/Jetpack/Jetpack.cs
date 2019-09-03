using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour
{

    float Fuel;
    bool CanUseJetpack;

    public float MaxFuelCapacity;
    public float FuelReductionFactor;
    public float RefillSpeed;
    public KeyCode ActivateJetpackInput;

    public Image Jauge;

    void Start()
    {

        Fuel = MaxFuelCapacity;
        CanUseJetpack = true;

    }

    void Update()
    {
        
        if (Input.GetKey(ActivateJetpackInput) && Fuel > 0f && CanUseJetpack)
        {

            //appliquer la force du jetpack

            Fuel -= Time.deltaTime * FuelReductionFactor;

        }

        if (Fuel <= 0) CanUseJetpack = false;

        if (!CanUseJetpack) Refill();

        Jauge.GetComponent<Image>().fillAmount = Fuel / MaxFuelCapacity;
       // Jauge.GetComponent<Image>().color = Color.Lerp(Color.red, Color.yellow, Fuel / MaxFuelCapacity);

    }

    void Refill()
    {

        Fuel += Time.deltaTime * RefillSpeed;

        if (Fuel>=MaxFuelCapacity) CanUseJetpack = true;

    }

}