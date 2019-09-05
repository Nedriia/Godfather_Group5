using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public RectTransform[] PauseUIButtons;
    public Image[] PauseIcon;

    float VerticalOffset;
    bool IsPaused;

    public Image ImageDispenser;
    public Sprite Story;
    public Sprite Controls;
    public float cooldown, cooldownMax;
    public bool image = false;
    
    void Start()
    {
        IsPaused = true;
        ImageDispenser.sprite = Story;
    }

    void Update()
    {
        if (image)
        {
            cooldown += Time.frameCount;
        }
        if (Input.GetKey(KeyCode.Joystick1Button1) && IsPaused && ImageDispenser.enabled)
        {
            if(ImageDispenser.sprite == Story)
            {
                ImageDispenser.sprite = Controls;
                image = true;
                
            }
            if(ImageDispenser.sprite == Controls && cooldown > cooldownMax)
            {
                ImageDispenser.enabled = false;
                IsPaused = false;
            }
        }

        if (IsPaused)
        {
            VerticalOffset = -1001f;
            Time.timeScale = 0f;
        }

        else
        {
            VerticalOffset = -1170f;
            Time.timeScale = 1f;
        }

        PauseIcon[0].enabled = IsPaused;
        PauseIcon[1].enabled = IsPaused;

        foreach (RectTransform rect in PauseUIButtons)
        {
            if (rect.anchoredPosition.y != VerticalOffset) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, Mathf.Lerp(rect.anchoredPosition.y, VerticalOffset, 0.3f));
        }

        if (Input.GetKeyDown(KeyCode.Escape)) IsPaused = !IsPaused;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene("scene TEST 2");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {

        IsPaused = false;

    }

}