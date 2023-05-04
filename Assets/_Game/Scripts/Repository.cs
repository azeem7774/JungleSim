using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository : MonoBehaviour
{
    [SerializeField] AudioSource m_PlayerAudioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        Register.OnRegister += RegisterPlayerAudioSource;
    }

    private void RegisterPlayerAudioSource(GameObject obj)
    {
        m_PlayerAudioSource = obj.GetComponent<AudioSource>();
        m_PlayerAudioSource.volume = PreferenceManager.SFxVolume;
    }
    
}
