using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectibles : MonoBehaviour
{
    // variables
    //score apearing in the inspector
    [SerializeField] private TextMeshProUGUI Score ;
    private int scoreValue ;


    // Start is called before the first frame update
    void Start()
    {
        // at the beggining the score is 0
        scoreValue = 0 ;
    }

    // Update is called once per frame
    void Update()
    {
        // apearing score and its value on the sreen
        Score.text = "Score : " + scoreValue ;

    }

    // call the fonction to detect if objects are collided
    private void OnTriggerEnter2D(Collider2D other)
    {
        // message in the console
        Debug.Log("+1") ;
        //
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject) ;
            scoreValue += 1 ;
        }
    }
}
