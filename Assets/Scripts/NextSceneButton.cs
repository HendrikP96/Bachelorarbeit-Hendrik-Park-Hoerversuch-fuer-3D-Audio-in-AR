// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class NextSceneButton : MonoBehaviour, IInputClickHandler
{
    public GameObject saveManager;
    public GameObject realSoundSource;

    void Awake()
    {
        gameObject.GetComponentInChildren<TextMesh>().text = "Starte Versuch";
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        
        //speicher Probantendaten der alten Szene
        saveManager.SendMessage("SaveDataForScene");

        // lade nächste Szene 
        realSoundSource.SendMessage("NextScene");

        GameObject.FindGameObjectWithTag("HearedSound").SendMessage("ComeBack");
        ClearBars();
        // Text des Buttons anpassen
        if (realSoundSource.GetComponent<RealSoundSource>().sceneName == null)
        {
            gameObject.GetComponentInChildren<TextMesh>().text = "Starte Versuch";
            GameObject.Find("Verabschiedung").GetComponent<Canvas>().enabled = true;

        }
        else
        {
            gameObject.GetComponentInChildren<TextMesh>().text = "Nächste Szene";
        }
    }

    private void ClearBars()
    {
        GameObject[] bars = GameObject.FindGameObjectsWithTag("Bar");

        foreach (GameObject bar in bars)
        {
            bar.SendMessage("ClearBar");
        }
    }

}

