using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Open the scene at index
    /// </summary>
    /// <param name="index"> the index of scene to be opened</param>
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
