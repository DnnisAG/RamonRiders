using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeManager : MonoBehaviour
{
    public void OnPressContinuar()
    {
        SessionManager.Instance.ResetLives();
        SessionManager.Instance.ResetScore();
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.NextScene();
    }
}
