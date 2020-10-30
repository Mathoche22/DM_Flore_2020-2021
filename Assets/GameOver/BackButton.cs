using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // call a function to go back
    public void GoBack()
    {
        // call the Menu scene
        SceneManager.LoadScene("MENU");
    }
}
