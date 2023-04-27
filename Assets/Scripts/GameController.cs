using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    float timer = 120f;
    [SerializeField]
    int neededPoints = 60;

    int goal;

    int points;
    public int lives;
    float currentTime;

    [SerializeField]
    TMP_Text textoScore;
    [SerializeField]
    TMP_Text textoTimer;
    [SerializeField]
    TMP_Text textoLives;
    [SerializeField]
    TMP_Text textoGoal;
    void Awake()
    {
        
        SessionManager sessionManager = SessionManager.Instance;
        points = sessionManager.GetScore();
        lives = sessionManager.GetLives();
        goal = sessionManager.GetScore() + neededPoints;
        currentTime = timer;
        textoGoal.text = neededPoints.ToString();
        textoScore.text = points.ToString();
        textoLives.text = lives.ToString();
    }


    private void OnEnable()
    {
        GemController.OnCollected += OnCollectibleCollected;
    }

    private void OnDisable()
    {
        GemController.OnCollected -= OnCollectibleCollected;
    }

    void OnCollectibleCollected()
    {
        textoScore.text = (++points).ToString();
        textoGoal.text = (--neededPoints).ToString();
    }

    void OnObstacleHit()
    {
        textoLives.text = (--lives).ToString();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            GameOver();
        }
        if (lives <= 0)
        {
            GameOver();
        }
        if (points >= goal)
        {
            LevelWon();
        }
    }

    void FixedUpdate()
    {
        int roundedTime = Mathf.RoundToInt(currentTime);
        textoTimer.text = roundedTime.ToString();
        textoLives.text = lives.ToString();
    }
    public void LoseLife()
    {
        lives--;
        SessionManager.Instance.LoseLives(1);
    }

    public void GameOver()
    {
        SessionManager.Instance.AddScore(points);
        SessionManager.Instance.ResetLives();
        Destroy(gameObject);
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.LastScene();
    }

    public void LevelWon()
    {
        SessionManager.Instance.AddScore(points);
        Destroy(gameObject);
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.NextScene();
    }

}
