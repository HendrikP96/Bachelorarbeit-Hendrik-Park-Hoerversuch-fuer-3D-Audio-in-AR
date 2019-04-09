using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarAction : MonoBehaviour
{
    public GameObject[] barList;
    public Material[] materials;
    public Material untriggeredMaterial;
    private int sensitivity;
    int clicked_index = -1;

    private void Start()
    {
        ClearBar();
    }

    private void checkActivation(string nameOfObject)
    {
        int intensity = 4;
        sensitivity = 0;
        if (clicked_index != -1) {
            ClearBar();
        }
        for (int bar_index = 0; bar_index <= barList.GetLength(0) - 1; bar_index++)
        {
            
            if (barList[bar_index].name.Equals(nameOfObject))
            {
                clicked_index = bar_index;

                if(clicked_index <= 4)
                {
                    for (int colored_bars = 4; colored_bars >= clicked_index; colored_bars--)
                    {
                        barList[colored_bars].SendMessage("RenderMe",materials[intensity]);
                        intensity--;
                        sensitivity--;
                        Debug.Log(sensitivity);
                    }
                }
                else {
                    for (int colored_bars = 5; colored_bars <= clicked_index; colored_bars++)
                    {
                        barList[colored_bars].SendMessage("RenderMe", materials[intensity+1]);
                        intensity++;
                        sensitivity++;
                        Debug.Log(sensitivity);
                    }
                }
            }
        }
    }

    public void ClearBar() {
        foreach (GameObject bar in barList) {
            bar.SendMessage("RenderMe", untriggeredMaterial);
        }
    }

    public int getSensitivity() {
        // sendmessage an speicher objekt mit der sensitvity
        return sensitivity;
    }


}


