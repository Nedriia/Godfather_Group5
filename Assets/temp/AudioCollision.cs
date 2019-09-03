using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour
{
    [Header("Sound Clip")]
    public AudioClip[] collisionSound;
    public AudioClip[] hurtSound;
    
    [Header("Audio Source")]
    public AudioSource hurtSound_Audio;
    public AudioSource collisionSound_Audio;
    public AudioSource flyPouletteOk;

    private bool isOverlapped = false;
    private bool playing = false;
    private bool pickAtime = false;

    [Header("Laugh Sound")]
    public float timeMini;
    public float timeMaxi;


    private void Update()
    {
        if(!pickAtime)
        {
            pickAtime = true;
            float timeToWait = Random.Range(timeMini, timeMaxi);
            StartCoroutine(WaitLaught(timeToWait));
        }

        if(isOverlapped == true)
        {
            if (!collisionSound_Audio.isPlaying || !hurtSound_Audio.isPlaying)
            {
                if (!playing)
                {
                    playing = true;
                    int collisionSound_toLoad = Random.Range(0, collisionSound.Length);
                    int hurtSound_toLoad = Random.Range(0, hurtSound.Length);

                    hurtSound_Audio.clip = collisionSound[collisionSound_toLoad];
                    collisionSound_Audio.clip = hurtSound[hurtSound_toLoad];

                    hurtSound_Audio.Play();
                    collisionSound_Audio.Play();


                    if (collisionSound[collisionSound_toLoad].length > hurtSound[hurtSound_toLoad].length)
                    {
                        StartCoroutine(Wait(collisionSound[collisionSound_toLoad].length));
                        Debug.Log(collisionSound[collisionSound_toLoad].length);
                    }
                    else if (collisionSound[collisionSound_toLoad].length < hurtSound[hurtSound_toLoad].length)
                    {
                        StartCoroutine(Wait(hurtSound[hurtSound_toLoad].length));
                        Debug.Log(hurtSound[hurtSound_toLoad].length);
                    }                   
                    else
                        StartCoroutine(Wait(collisionSound[collisionSound_toLoad].length));
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOverlapped = true;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        isOverlapped = false;
        playing = false;
    }

    IEnumerator WaitLaught(float time)
    {
        yield return new WaitForSeconds(time);
        flyPouletteOk.Play();
        pickAtime = false;
    }
}
