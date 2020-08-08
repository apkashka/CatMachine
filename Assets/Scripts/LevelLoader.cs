using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Image _progressImage=null;

    private void Start()
    {
        StartCoroutine(LoadLevel());
    }
   public IEnumerator LoadLevel()
    {
        yield return new WaitForEndOfFrame();
        AsyncOperation operation = SceneManager.LoadSceneAsync("SampleScene");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            _progressImage.fillAmount = progress;
            yield return null;
            if (operation.progress>=0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
