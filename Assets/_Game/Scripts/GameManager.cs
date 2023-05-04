using System;
using System.Collections;
using System.Collections.Generic;
using Gamingale;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action OnGameWin;
    public Action<int> OnSceneLoaded;
    [SerializeField] private LevelManager m_LevelManager;
    [SerializeField] private UIManager m_UIManager;
    [SerializeField] private SceneLoader m_SceneLoader;
    public static GameManager Instance;

    #region Properties
    public UIManager UIManager
    {
        set
        {
            m_UIManager =value;
        }
    }
    public SceneLoader SceneLoader
    {
        set
        {
            m_SceneLoader = value;
        }
    }
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    // ++ Future Refinement: this not a good approach to call SceneLoader's function in GameManager
    private void OnEnable()
    {
        m_UIManager.OnLoadingComplete += m_SceneLoader.LoadScene;
    }

    

    private void OnDisable()
    {
        m_UIManager.OnLoadingComplete -= m_SceneLoader.LoadScene;
    }

}
