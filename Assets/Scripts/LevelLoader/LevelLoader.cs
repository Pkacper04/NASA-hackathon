using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation= SceneManager.LoadSceneAsync(sceneIndex);

        while(!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}
