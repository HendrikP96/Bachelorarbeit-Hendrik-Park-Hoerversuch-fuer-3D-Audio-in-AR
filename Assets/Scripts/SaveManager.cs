using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public GameObject hearedSoundSource;
    public GameObject[] bars;
    public GameObject realSoundSource;

    private void Start()
    {
        bars = GameObject.FindGameObjectsWithTag("Bar");
    }
    string CreatePath(string currentSceneName)
    {
        // Legt fest in welcher Szenen-Datei die Probantendaten gespeichert werden
        //string filename = realSoundSource.GetComponent<RealSoundSource>() + ".txt";
        string filename = currentSceneName + ".txt";
        string path = Path.Combine(Application.persistentDataPath, filename);
        return path;
    }

    string CollectInfo()
    {
        // Zusammensetzen des Strings aus Kugel-Zentrums-Position, Plausibilitätsgefühl und Immersionsgefühl
        string soundSrcPos = hearedSoundSource.transform.localPosition.x.ToString() + " " + hearedSoundSource.transform.localPosition.y.ToString() + " " + hearedSoundSource.transform.localPosition.z.ToString();
        string info = soundSrcPos;
        foreach (GameObject bar in bars)
        {
            info = info + " " +  bar.GetComponent<BarAction>().getSensitivity().ToString(); 
        }
        Debug.Log(info);
        return info;
    }
    void SaveDataForScene()
    {
        string currentSceneName = realSoundSource.GetComponent<RealSoundSource>().sceneName;
        if(currentSceneName != null)
        {
            // Speichert für jede Szene die Probanten-Daten
            Debug.Log("SaveDataForScene");
            File.AppendAllText(CreatePath(currentSceneName), CollectInfo() + Environment.NewLine);
        }
    }
}
