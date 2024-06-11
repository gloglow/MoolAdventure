using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private GameObject playerCharacter;
    public int connectedSceneNum;

    private void Start()
    {
        playerCharacter = GameManager.Instance.playerCharacter;
        if (connectedSceneNum == GameManager.sceneLoader.crtSceneNum)
        {
            playerCharacter.transform.position = transform.position;
            GameManager.sceneLoader.crtSceneNum = GameManager.sceneLoader.nextSceneNum;
        }
    }
}
