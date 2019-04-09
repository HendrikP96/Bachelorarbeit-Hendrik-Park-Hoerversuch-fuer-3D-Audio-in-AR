using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Scene_Analyzer : MonoBehaviour
{
    public GameObject prefab;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        string[] bits;
        float x,y,z;
        using (TextReader reader = File.OpenText(sceneName +".txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                bits = line.Split(' ');
                x = float.Parse(bits[0], System.Globalization.CultureInfo.InvariantCulture);
                y = float.Parse(bits[1], System.Globalization.CultureInfo.InvariantCulture);
                z = float.Parse(bits[2], System.Globalization.CultureInfo.InvariantCulture);
                Debug.Log(x + " " + y + " " + z);
                GameObject sphere = Instantiate<GameObject>(prefab, GameObject.Find("HoloGrammCollection").transform, false);
                sphere.transform.localPosition = new Vector3(x, y, z);
            }
        }



    }
}
