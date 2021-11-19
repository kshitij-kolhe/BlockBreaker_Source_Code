using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)]
    [SerializeField] float gameSpeed = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int pointsPerBlock;
    [SerializeField] int p;

    int score = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = score.ToString();
       // print(p + "....." + FindObjectsOfType<GameSession>().Length);
    }

    
    void Update()
    {
        Time.timeScale = gameSpeed;    
    }

    public void UpdateScore()
    {
        score += pointsPerBlock;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}
