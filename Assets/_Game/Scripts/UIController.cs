using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    private GameController gameController;

    public GameObject panelMainMenu, panelGame, panelPause, panelGameOver;

    public TMP_Text txtHighscore, txtTime, txtScore;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
        txtHighscore.text = $"Highscore: {gameController.GetScore().ToString()}";
    }

    public void ButtonExit(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void ButtonStart(){
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.StartGame();
    }

    public void ButtonPause(){
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ButtonResume(){
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ButtonRestartGame(){
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        gameController.StartGame();
        txtScore.text = gameController.score.ToString();
        Time.timeScale = 1f;
    }

    public void ButtonBackToMainMenu(){
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        gameController.BackToMainMenu();
        txtHighscore.text = $"Highscore: {gameController.GetScore().ToString()}";
        txtScore.text = gameController.score.ToString();
        Time.timeScale = 1f;
    }
}
