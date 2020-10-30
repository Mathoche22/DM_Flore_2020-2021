using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // create a fonction fo each button

    public void PlayButton()
    {
        // call the scene to load
        SceneManager.LoadScene("PLAY");
    }

    public void CreditButton()
    {
        // call the scene to load
        SceneManager.LoadScene("CREDITS");
    }

    public void QuitButton()
    {
        // call Tthe function that quit the game
        Application.Quit();
    }
}
