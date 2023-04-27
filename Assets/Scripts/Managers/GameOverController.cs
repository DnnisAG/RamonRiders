using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreTexto;



    void Start()
    {
        int score = SessionManager.Instance.GetScore();
        scoreTexto.text = score.ToString();

    }

    public void OnPressEmpezar()
    {
        SessionManager.Instance.ResetScore();
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.FirstScene();
    }
}
