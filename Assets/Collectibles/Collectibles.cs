using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collectibles : MonoBehaviour
{
    //score apearing in the inspector
    [SerializeField] private TextMeshProUGUI Score ;
    // int to code the result of the score
    private int ScoreValue ;


    void Start()
    {
        // at the lounch the score is 0
        ScoreValue = 0 ;
    }


    void Update()
    {
        // apearing score and its value on the sreen
        Score.text = "Score : " + ScoreValue ;

    }

    // call the fonction to detect if objects are collided
    private void OnTriggerEnter2D(Collider2D other)
    {
        // message in the console
        Debug.Log("+1") ;
        //when the fox collides with a collectible, they're destroyed and +1 to the score
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject) ;
            ScoreValue += 1 ;
        }
    }
}
