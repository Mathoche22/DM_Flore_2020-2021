using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   
   // one fonction per button

   public void PLAYButton()
   {
       //load the play scene
       SceneManager.LoadScene("PLAY") ;
   }
   
   public void CREDITSButton()
   {
       //load the credits scene
       SceneManager.LoadScene("CREDITS") ;
   }
   
   public void QUITButton()
   {
       // quit the game adn close the app
       Debug.Log("close") ;
       Application.Quit() ;
   }

   
}
