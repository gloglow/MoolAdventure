using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public int sceneNum;
    public TextMeshProUGUI portalText;
    private float timer;
    public float waitTime;

    public IEnumerator OnPortal()
    {
        portalText.gameObject.SetActive(true);
        timer = 0;

        while(timer < waitTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        GameManager.instance.MoveScene(sceneNum);
    }

    public void OffPortal()
    {
        StopCoroutine(OnPortal());
    }
}
