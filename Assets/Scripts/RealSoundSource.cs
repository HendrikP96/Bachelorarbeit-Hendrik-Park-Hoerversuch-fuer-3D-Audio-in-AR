using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RealSoundSource : MonoBehaviour
{
    Renderer rend;

    // Orte an denen die Schallquelle platziert wird

    public AudioClip wolf_Sound;
    public AudioClip voegel_Sound;
    public AudioClip kirchenglocken_Sound;
    public AudioClip Rosa_Rauschen_Sound;
    public AudioClip fluss_Sound;
    public AudioClip frosch_Sound;

    int sceneNumber;
    public string sceneName;

    AudioSource realAudioSource;

    // Start is called before the first frame update
    void Awake()
    {
        realAudioSource = gameObject.GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        sceneName = null;
        sceneNumber = 0;
    }

    public void ShowSource() {
        rend.enabled = true;
    }
    public void HideSource()
    {
        rend.enabled = false;
    }

    public void NextScene()
    {
        sceneNumber++;
        Debug.Log("Schallquelle stellt neue Szene ein");
        switch(sceneNumber)
        {
            case 1:
                // Vögel alleine, nur Gerüst
                sceneName = "Szene_1_Vogelnest";
                gameObject.transform.position = GameObject.Find("Vögel").transform.position;
                realAudioSource.clip = voegel_Sound;
                realAudioSource.volume = 0.5f;
                realAudioSource.Play();
                break;

            case 2:
                // Wolf alleine, zwei Wölfe im Bild der Schwarze ist der richtige
                sceneName = "Szene_2_Wolf_alleine";
                gameObject.transform.position = GameObject.Find("Wolf").transform.position;
                realAudioSource.clip = wolf_Sound;
                realAudioSource.volume = 0.5f;
                realAudioSource.Play();
                break;
            case 3: 
                // Kirchenglocke 3D Sound aus 
                sceneName = "Szene_3_Kirchenglocke_alleine";
                gameObject.transform.position = GameObject.Find("Glockenrumpf").transform.position;
                realAudioSource.clip = kirchenglocken_Sound;
                realAudioSource.volume = 0.5f;
                realAudioSource.spatialBlend = 0;
                realAudioSource.spatialize = false;
                realAudioSource.Play();
                break;
            case 4:
                // Vogel in der Luft über dem Probanden
                realAudioSource.spatialBlend = 1;
                realAudioSource.spatialize = true;
                sceneName = "Szene_4_Vogel_Luft";
                gameObject.transform.position = GameObject.Find("Adler_Luft").transform.position;
                realAudioSource.clip = voegel_Sound;
                realAudioSource.volume = 0.5f;
                realAudioSource.Play();
                break;
            case 5:
                // Fluss mit zwei Schallquellen
                sceneName = "Szene_5_fluss";
                gameObject.transform.position = GameObject.Find("Boot").transform.position;
                GameObject.Find("Unterstützer Schallquelle").SendMessage("PlaySupportSound");
                realAudioSource.clip = fluss_Sound;
                realAudioSource.volume = 0.5f;
                realAudioSource.Play();
                break;
            case 6:
                // Abschluss Szene: kein Sound
                GameObject.Find("Unterstützer Schallquelle").SendMessage("StopSupportSound");
                realAudioSource.Stop();
                sceneName = null;
                sceneNumber = 0;
                break;
            default:
                break;
        }

    }

    
}
