using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeManager : MonoBehaviour
{
    public void OnPressContinuar()
    {
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.NextScene();
    }
}
