using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
