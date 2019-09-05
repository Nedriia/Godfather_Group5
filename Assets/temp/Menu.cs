using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool controlsOn;
    public GameObject Controls;
    public GameObject MenuDisplay;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Joystick1Button1) && controlsOn)
        {
            Controls.SetActive(false);
            MenuDisplay.SetActive(true);
            controlsOn = false;
        }
    }
    public void loadLevel()
    {
        SceneManager.LoadScene("scene TEST 2");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void ControlsDisplay()
    {
        MenuDisplay.SetActive(false);
        Controls.SetActive(true);
        controlsOn = true;
    }
}
