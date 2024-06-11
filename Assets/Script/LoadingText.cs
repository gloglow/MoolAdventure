using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private TextMeshProUGUI loadingText;

    private void Awake()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation _asyncOperation = SceneManager.LoadSceneAsync(GameManager.sceneLoader.nextSceneNum);
        _asyncOperation.allowSceneActivation = false;
        float timer = 0f;

        while(!_asyncOperation.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if(_asyncOperation.progress < 0.9f)
            {
                loadingSlider.value = Mathf.Lerp(loadingSlider.value, _asyncOperation.progress, timer);
                if(loadingSlider.value >= _asyncOperation.progress)
                    timer = 0f;
            }
            else
            {
                loadingSlider.value = Mathf.Lerp(loadingSlider.value, 1f, timer);
                if(loadingSlider.value == 1.0f)
                {
                    _asyncOperation.allowSceneActivation = true;
                    yield break;
                }
            }
            int _progressPercentage = Mathf.RoundToInt(loadingSlider.value * 100f);
            loadingText.text = "Loading... " + _progressPercentage.ToString() + "%";
        }
    }
}
