// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class BarToggle : MonoBehaviour, IInputClickHandler
{
    GameObject parent;
    Renderer rend;

    void Start()
    {
        parent = transform.parent.gameObject;
        rend = GetComponent<Renderer>();
    }

    public void RenderMe(Material material)
    {
        if(rend != null)
            rend.sharedMaterial = material;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        parent.SendMessage("checkActivation", name);
    }

}

