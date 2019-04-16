using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    //Function for Loading scene by index
    public void scena(int scena)
    {
        SceneManager.LoadScene(scena);
    }

    //Function for deleting save file when finishing last level in ufo game
    public void LastLevel()
    {
        PlayerPrefs.DeleteKey("ufolv");
        SceneManager.LoadScene(4);
    }

    //Fucntion for restarting the active scene by index
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Function for quiting the application
    public void Quit()
    {
        Application.Quit();
    }
}
