using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public void scena(int scena)
    {
        SceneManager.LoadScene(scena);
    }

    public void LastLevel()
    {
        PlayerPrefs.DeleteKey("ufolv");
        SceneManager.LoadScene(4);
    }
}
