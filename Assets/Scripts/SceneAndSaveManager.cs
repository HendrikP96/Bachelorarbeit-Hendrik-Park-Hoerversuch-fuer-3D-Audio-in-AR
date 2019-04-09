using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndSaveManager : MonoBehaviour
{

    public GameObject soundSource;
    public GameObject plausibilityBar;
    public GameObject immersionBar;
    public string nextSceneName;

    string CreatePath()
    {
        // Legt fest in welcher Szenen-Datei die Probantendaten gespeichert werden
        string filename =  SceneManager.GetActiveScene().name + ".txt";
        string path = Path.Combine(Application.persistentDataPath, filename);
        return path;
    }

    string CollectInfo()
    {
        // Zusammensetzen des Strings aus Kugel-Zentrums-Position, Plausibilitätsgefühl und Immersionsgefühl
        string SoundSrcPos = soundSource.transform.position.x.ToString() + " " + soundSource.transform.position.y.ToString() + " " + soundSource.transform.position.z.ToString();
        string plausibility = plausibilityBar.GetComponent<BarAction>().getSensitivity().ToString();
        string immersion = immersionBar.GetComponent<BarAction>().getSensitivity().ToString();

        string info = SoundSrcPos + " " + plausibility + " " + immersion;
        Debug.Log(info);
        return info;
    }
    void LoadNextScene()
    {
        // Speichert für jede Szene die Probanten-Daten
        Debug.Log("LoadNextScene wurde aktiviert");
        File.AppendAllText(CreatePath(), CollectInfo() + Environment.NewLine);
        if(nextSceneName != null)
            SceneManager.LoadScene(nextSceneName);
    }
}
