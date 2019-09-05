using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class ScoreManager : MonoBehaviour
{
    public PostProcessingBehaviour test;
    float Score;
    int ScoreMultiplier;
    public Text[] ScoreText;

    public Image CooldownMask;
    public Text[] ScoreMultiplierText;
    float Cooldown;
    public float MaxCooldown;

    public int ScorePerMultiplier;

    public GameObject AddScoreText;
    public GameObject Canvas;

    int TargetSize = 100;

    [Header("Input value")]
    public float leftTrigger;
    public float rightTrigger;

    void Start()
    {
        test = Camera.main.GetComponent<PostProcessingBehaviour>();
        Cooldown = MaxCooldown;
        ScoreMultiplier = 1;
        var testtest = test.profile.chromaticAberration.settings;
        testtest.intensity = 1;
        test.profile.chromaticAberration.settings = testtest;
        
    }

    void Update()
    {
        leftTrigger = Input.GetAxis("LeftTrigger");
        rightTrigger = Input.GetAxis("RightTrigger");

        leftTrigger = Mathf.Clamp(leftTrigger, 0, 1);
        rightTrigger = Mathf.Clamp(rightTrigger, 0, 1);

        if (leftTrigger != 0 && rightTrigger != 0)
        {
            ScoreMultiplier = 0;
        }

            ScoreText[0].text = Score.ToString();
        ScoreText[1].text = Score.ToString();

        ScoreMultiplierText[0].text = "x" + ScoreMultiplier;
        ScoreMultiplierText[1].text = "x" + ScoreMultiplier;
        CooldownMask.fillAmount = Cooldown / 5f;

        if (ScoreMultiplier > 1)
        {
            Cooldown -= Time.deltaTime;
        }

        if (ScorePerMultiplier >= ScoreMultiplier)
        {
            StartCoroutine(ChangeMultiplier());
            ScoreMultiplier++;
        }

        ScoreMultiplierText[0].gameObject.SetActive(ScoreMultiplier > 1);
        ScoreMultiplierText[1].gameObject.SetActive(ScoreMultiplier > 1);

        if (Cooldown <= 0)
        {
            ScoreMultiplier--;
            StartCoroutine(ChangeMultiplier());

            Cooldown = MaxCooldown;
        }

        foreach(Text txt in ScoreMultiplierText)
        {

            if (txt.fontSize != TargetSize) txt.fontSize = Mathf.RoundToInt(Mathf.Lerp(txt.fontSize, TargetSize, Time.deltaTime * 20f));

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "0" || collision.transform.tag == "100" || collision.transform.tag == "300" || collision.transform.tag == "900")
        {
            ScorePerMultiplier++;

            Score += float.Parse(collision.transform.tag) * ScoreMultiplier;

            GameObject InstantiatedText = Instantiate(AddScoreText);
            InstantiatedText.transform.SetParent(Canvas.transform);
            InstantiatedText.GetComponent<Text>().text = "+" + float.Parse(collision.transform.tag) * ScoreMultiplier;        
        }
    }

    IEnumerator ChangeMultiplier()
    {

        ScorePerMultiplier = 0;
        TargetSize = 120;
        yield return new WaitForSeconds(0.05f);
        TargetSize = 100;

    }

}