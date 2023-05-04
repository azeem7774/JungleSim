using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Helper
{
    public static void ToggleGameObjects(GameObject[] gos, bool enable)
    {
        for (int i = 0; i < gos.Length; i++)
            gos[i].SetActive(enable);
    }

    public static void ToggleInteractableButton(Button[] btns, int length, bool enable)
    {
        for (int i = 0; i < length; i++)
        {
            btns[i].interactable = enable;
        }
    }
    
}
