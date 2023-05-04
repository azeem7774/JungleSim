using System.Collections;
using System.Collections.Generic;
using Gamingale;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private GameManager m_GameManager; 
    [SerializeField] private UIManager m_UIManager;
    [SerializeField] private SceneLoader m_SceneLaoder;
    
    void Start()
    {
        Application.targetFrameRate = 60;
        Init();
        Invoke("ShowBanner", 3);
    }
    void Init()
    {

        //GameObject UI = Instantiate(m_UIManager.gameObject);
        //GameObject SL = Instantiate(m_SceneLaoder.gameObject);
        //m_GameManager.UIManager = UI.GetComponent<UIManager>();
        //m_GameManager.SceneLoader = SL.GetComponent<SceneLoader>();
    }
    void ShowBanner()
    {
        MaxAdManager.Instance.ShowBanner();
    }
}
