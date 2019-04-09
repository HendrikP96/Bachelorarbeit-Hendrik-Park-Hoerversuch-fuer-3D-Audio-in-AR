using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportSoundSource : MonoBehaviour
{
    AudioSource SupportAudioSource;

    void Awake()
    {
        SupportAudioSource = gameObject.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void PlaySupportSound()
    {
        SupportAudioSource.volume = 0.5f;
        SupportAudioSource.Play();
    }
    void StopSupportSound()
    {
        SupportAudioSource.Stop();
    }
}
