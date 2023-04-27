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
    [SerializeField]
    int startingLives = 3;

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
        currentTime = timer;
        lives = startingLives;
        textoGoal.text = neededPoints.ToString();
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
        if (points >= neededPoints)
        {
            GameWon();
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
    }

        public void GameOver()
    {
        SessionManager.Instance.AddScore(points);
        Destroy(gameObject);
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.NextScene();
    }

    public void GameWon()
    {
        SessionManager.Instance.AddScore(points);
        Destroy(gameObject);
        LevelManager scene = FindObjectOfType<LevelManager>();
        scene.LastScene();
    }
}
