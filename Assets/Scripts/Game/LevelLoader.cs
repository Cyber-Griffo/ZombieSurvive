using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Slider progressBar;
    public GameObject loadingScreen;

    public void LoadLevel(string name)
    {
        StartCoroutine(LoadAsynchronously(name));
    }

    IEnumerator LoadAsynchronously(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);

            progressBar.value = progress;

            yield return null;
        }
    }

    public void SetLoadingScreenActive(bool value)
    {
        loadingScreen.SetActive(value);
    }
}
