using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public Animator transitor;
    public float timeTotransition = 6f;

    public void LoadNextLevel(string SceneName)
    {
        StartCoroutine(LoadLevel(SceneName));
    }

    // Update is called once per frame
    IEnumerator LoadLevel(string SceneName)
    {
        transitor.SetTrigger("StartTransition");
        yield return new WaitForSeconds(timeTotransition);
        SceneManager.LoadScene(SceneName);
    }
}
