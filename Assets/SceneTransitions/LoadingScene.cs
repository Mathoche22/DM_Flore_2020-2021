using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // get the animations
    Animator animator;
    // set a time for the transition
    public float transitionTime = 1.5f;
    // the next scene can be changed in the inspector
    [SerializeField] public int NextScene;

    private void Awake()
    {
        // get a component on the animation
        animator = GetComponent<Animator>();
    }

    // function to call the transition scene animation
    public void LoadScene()
    {
        // apply a scene to call
        NextScene = SceneManager.GetActiveScene().buildIndex + 1; 
        // call the next scene
        StartCoroutine(LoadScene(NextScene));
    }

    IEnumerator LoadScene(int buil_index)
    {
        animator.SetTrigger("EndLoad");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(buil_index);
    }

}
