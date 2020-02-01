using UnityEngine;
using UnityEngine.SceneManagement;
public class PressToPlay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
