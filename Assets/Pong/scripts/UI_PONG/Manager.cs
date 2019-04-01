using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void MultyplayerScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SinglePlayerScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
