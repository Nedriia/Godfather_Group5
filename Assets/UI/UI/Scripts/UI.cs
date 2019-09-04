using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject Player;

    public bool UIEnabled;
    public bool IsWinScreen;
    public Image FinishText;

    public Sprite[] WinLoseSprite;

    public RectTransform FinishTitle;
    public RectTransform[] Buttons;

    float ButtonVerticalOffset;
    float TitleHorizontalOffset;

    float Timer;

    public Text TimerText;
    public Text ScoreText;
    public Text HitText;

    void Start()
    {

        Timer = 0f;

    }

    void Update()
    {

        if (!UIEnabled) Timer += Time.deltaTime;

        TimerText.text = "TIME OF FLIGHT : " + Mathf.RoundToInt(Timer).ToString() + "s";

        //ScoreText.text = "SCORE : " + Player.GetComponent<ScoreManager>().Score.ToString();
        //HitText.text = "OBJECTS HIT : " + Player.GetComponent<ScoreManager>().HitObjects.ToString();

        if (IsWinScreen)
        {
            GetComponent<Image>().color = new Color(0, 1, 0, 0.2f);
            FinishText.sprite = WinLoseSprite[0];
        }

        else
        {
            GetComponent<Image>().color = new Color(1, 0, 0, 0.2f);
            FinishText.sprite = WinLoseSprite[1];
        }

        if (UIEnabled)
        {

            ButtonVerticalOffset = -955f;
            TitleHorizontalOffset = 960f;

        }

        else
        {

            ButtonVerticalOffset = -1205f;
            TitleHorizontalOffset = -300f;

        }

        TimerText.gameObject.SetActive(UIEnabled);
        ScoreText.gameObject.SetActive(UIEnabled);
        HitText.gameObject.SetActive(UIEnabled);

        GetComponent<Image>().enabled = UIEnabled;

        foreach (RectTransform rect in Buttons)
        {
            if (rect.anchoredPosition.y != ButtonVerticalOffset) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, Mathf.Lerp(rect.anchoredPosition.y, ButtonVerticalOffset, Time.deltaTime * 7f));
        }

        if (FinishTitle.anchoredPosition.x != TitleHorizontalOffset) FinishTitle.anchoredPosition = new Vector2(Mathf.Lerp(FinishTitle.anchoredPosition.x, TitleHorizontalOffset, Time.deltaTime * 7f), FinishTitle.anchoredPosition.y);

    }

}