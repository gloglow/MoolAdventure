using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public static InputManager inputManager;
    public static SceneLoader sceneLoader;

    public GameObject playerCharacter;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        inputManager = GetComponent<InputManager>();
        sceneLoader = GetComponent<SceneLoader>();
    }
    private void Start()
    {
        sceneLoader.LoadScene();
    }
}
