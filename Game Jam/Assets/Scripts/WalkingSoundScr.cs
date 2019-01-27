using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSoundScr : MonoBehaviour
{
    AudioSource Sound;

    void Update()
    {
        Sound = GetComponent<AudioSource>();
        int activity = GetComponent<Animator>().GetInteger("Move");
        if(activity != 0 && !Sound.isPlaying)
        {
            Debug.Log("Sound.Play");
            Sound.Play();
        }
        else
        {
            if (activity == 0)
            {
                Debug.Log("Sound.Stop");
                Sound.Stop();
            }
        }
    }
}
