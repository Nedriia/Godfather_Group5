using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoqAudioLaugh2 : MonoBehaviour
{
    [Header("Sound Clip")]
    public AudioClip[] LaughSound;

    [Header("Audio Source")]
    public AudioSource LaughSound_Audio;

    private bool pickAtime = false;

    [Header("Laugh Sound")]
    public float timeMini;
    public float timeMaxi;


    private void Update()
    {
        if (!pickAtime)
        {
            pickAtime = true;
            float timeToWait = Random.Range(timeMini, timeMaxi);
            int audioToPlay = Random.Range(0, LaughSound.Length);
            LaughSound_Audio.clip = LaughSound[audioToPlay];
            StartCoroutine(WaitLaught(timeToWait));
        }
    }

    IEnumerator WaitLaught(float time)
    {
        yield return new WaitForSeconds(time);
        LaughSound_Audio.Play();
        pickAtime = false;
    }
}
