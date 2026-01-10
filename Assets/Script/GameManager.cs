using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score, highScore;
    public TextMeshProUGUI scoreText, highScoreText;
    public readonly string HIGHSCORE = "HIGHSCORE";

    public bool isGameOver;

    private int Score
    {
        get => score;
        set
        {
            score = value;
            //contoh menambahkan N0 bukn NO untuk memberikan titik diangka misalnya 1.000
            scoreText.text = $"Score: {score :N0}";
            // scoreText.text = "Score: "+ score.ToString("N0");
        }
    }

    private int HighScore
    {
        get => highScore;
        set
        {
            highScore = value;
            //contoh menambahkan N0 bukn NO untuk memberikan titik diangka misalnya 1.000
            highScoreText.text = $"High-Score: {highScore :N0}";
            // scoreText.text = "Score: "+ score.ToString("N0");
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Score = 0;
        HighScore = PlayerPrefs.GetInt(HIGHSCORE, 0);
    }

    public void AddScore(int scoreValue)
    {
        if(isGameOver) return;
        Score += scoreValue;
        
    }
    // Update is called once per frame
    void Update()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void IsGameOver()
    {
        isGameOver = true;
        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt(HIGHSCORE, HighScore);
        }
    }
}
