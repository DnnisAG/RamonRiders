using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Tooltip("Contains the animator controler for scene transitions")]
    [SerializeField]
    Animator animator;

    [Tooltip("amount of secs to wait before start scene transition")]
    [SerializeField]
    float transitionTime = 1.0F;

  
    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

   
    public void FirstScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LastScene()
    {
        SceneManager.LoadScene(3);
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        animator.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
