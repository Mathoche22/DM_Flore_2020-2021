using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    Animator animator;
    public float transitionTime = 1.5f;
    [SerializeField] public int NextScene;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void LoadNextScene()
    {
        NextScene = SceneManager.GetActiveScene().buildIndex + 1; 
        StartCoroutine(LoadingScene(NextScene));
    }

    IEnumerator LoadingScene(int buil_index)
    {
        animaor.SetTrigger("EndLoad");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadingScene(buil_index);
    }
}
