using System;
using System.Collections;
using System.Collections.Generic;
using Gamingale;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //[SerializeField] private UIManager m_UIManager;
    [SerializeField] private SceneName m_SceneName;
    public SceneName SceneNameEnum => m_SceneName;
    public static SceneLoader Instance;
    int sceneIndex;

    
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
    private void Start()
    {
        m_SceneName = SceneName.Splash;
    }

    public void LoadScene()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        //++Future Refinement: This is patch.
        if (Constants.m_IsCurrenSceneToBeLoaded)
        {
            Constants.m_IsCurrenSceneToBeLoaded = false;
        }
        else
        {
            sceneIndex = sceneIndex % 2 == 0 ? 1 : ++sceneIndex;
        }
        m_SceneName = (SceneName)sceneIndex;
        IEnumerator coroutine = LoadSceneWithIndex(sceneIndex);
        StartCoroutine(coroutine);

    }
    IEnumerator LoadSceneWithIndex(int sceneIndex)
    {
        Constants.m_IsSceneLoaded = false;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
            yield return null;
        Constants.m_CurrentScene = (SceneName)sceneIndex;
        Constants.m_IsSceneLoaded = true;
    }
    
    
    
}
public enum SceneName
{
    Splash,
    MainMenu,
    Gamplay,
    Gameplay_Nignt,
    Gameplay_OpenWorld
}