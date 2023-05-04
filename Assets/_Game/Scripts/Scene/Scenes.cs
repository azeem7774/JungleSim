using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneContainer", menuName ="SceneContainer/CreateSceneContainer" )]
public class Scenes : ScriptableObject
{
    public SceneData[] m_SceneData;
}
[Serializable]
public struct SceneData
{
    public int m_SceneIndex;
    public string m_SceneName;
#if UNITY_EDITOR
    //this method need a research to implement
    public UnityEngine.Object m_Scenes;
#endif
}