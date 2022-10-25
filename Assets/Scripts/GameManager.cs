using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    
    public GameObject newBall;
    public GameObject displayBall;

    public static GameManager instance;
    public GameObject gameoverscreen;

    public int ballsLeft = 3;
    float highscore = 0;

    public float current_score = 0;

    TMP_Text highscoretext;


    GameObject[] displayBalls;
    // Start is called before the first frame update
    private void Start()
    {
        instance = this;
        highscoretext = GameObject.FindGameObjectWithTag("HighscoreDisplay").GetComponent<TMP_Text>();

        displayBalls = new GameObject[ballsLeft];
        for(int i = 0; i < ballsLeft; i++)
        {
            GameObject ball = Instantiate(displayBall, GameObject.Find("Canvas").transform);
            RectTransform rect = ball.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector3(rect.anchoredPosition.x + (i * rect.rect.width + 10), rect.anchoredPosition.y);
            displayBalls[i] = ball;
        }
    }

    void UpdateDisplayBalls()
    {
        for(int i = 0; i < displayBalls.Length; i++)
        {
            displayBalls[i].SetActive(i < ballsLeft);
        }
    }
    public void SubtractBall(float score)
    {
        current_score += score;
        if (--ballsLeft <= 0)
        {
            GameOver();
        }
        else {
            Instantiate(newBall);
        }
        UpdateDisplayBalls();
    }
    public void GameOver() {


        gameoverscreen.transform.Find("Body").GetComponent<TMP_Text>().text = "Score: " + current_score + "\nHighscore: " + (highscore > current_score ? highscore : current_score) + (current_score > highscore ? "\nNew highscore!" : "");
        gameoverscreen.SetActive(true);
        highscore = highscore < current_score ? current_score : highscore;
        Instantiate(newBall);


    }
    public void Restart()
    {
        highscoretext.text = "Highscore: " + highscore;
        current_score = 0;
        gameoverscreen.SetActive(false);
        current_score = 0;
        ballsLeft = 3;
        UpdateDisplayBalls();
    }
}
