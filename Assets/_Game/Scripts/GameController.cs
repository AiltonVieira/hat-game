using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public int score;

    private int highscore;

    [SerializeField] private float startTime;

    private float currentTime;

    private UIController uIController;

    [HideInInspector] public bool gameStarted;

    [SerializeField] private Transform player;

    private Vector2 playerPosition;

    void Start()
    {
        gameStarted = false;
        uIController = FindObjectOfType<UIController>();
        highscore = GetScore();
        uIController.txtTime.text = currentTime.ToString();
        playerPosition = player.position;
    }

    private void SaveScore() {
        if(score > highscore) {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        return;
    }

    public int GetScore(){
        int highscore = PlayerPrefs.GetInt("highscore");
        return highscore;
    }

    public void InvokeCountDownTime(){
        InvokeRepeating("CountDownTime", 0f, 1f);
    }

    public void StartGame(){
        score = 0;
        currentTime = startTime;
        gameStarted = true;
        InvokeCountDownTime();
        player.position = playerPosition;
    }

    public void BackToMainMenu(){
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        CancelInvoke("CountDownTime");
        player.position = playerPosition;
    }

    void CountDownTime()
    {
        uIController.txtTime.text = currentTime.ToString();
        if(currentTime > 0f && gameStarted){
            currentTime -= 1f;
            float currentTimeToInt = Mathf.RoundToInt(currentTime);
        } else {
            uIController.panelGameOver.gameObject.SetActive(true);
            uIController.panelGame.gameObject.SetActive(false);
            gameStarted = false;
            currentTime = 0f;
            SaveScore();
            CancelInvoke("CountDownTime");
            return;
        }
    }
}
