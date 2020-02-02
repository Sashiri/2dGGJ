using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelAfterSeconds : MonoBehaviour
{
    public float seconds = 2;
    public string levelName = "";
    public LevelLoader loader;
    private void Awake()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(seconds);
        loader.LoadNextLevel(levelName);
    }
}
