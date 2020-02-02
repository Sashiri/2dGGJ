using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterVideo : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer cinematic;
    public string levelName;
    private void Start()
    {
        cinematic.loopPointReached += (_) => SceneManager.LoadScene(levelName);
        cinematic.Play();
    }
}
