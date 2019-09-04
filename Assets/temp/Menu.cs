using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void loadLevel()
    {
        SceneManager.LoadScene("scene TEST");
    }

    public void quit()
    {
        Application.Quit();
    }
}
