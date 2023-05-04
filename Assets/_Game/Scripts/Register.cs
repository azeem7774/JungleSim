using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
    public static Action<GameObject> OnRegister;

    private void OnEnable()
    {
        OnRegister?.Invoke(gameObject);
    }
}
