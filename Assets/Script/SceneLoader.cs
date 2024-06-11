using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int crtSceneNum;
    public int nextSceneNum;

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
