using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider m_SfxSlider;

    private void Start()
    {
        m_SfxSlider.value = PreferenceManager.SFxVolume;
    }

    public void SetSfxVolume()
    {
        PreferenceManager.SFxVolume = m_SfxSlider.value;
    }
    
}
