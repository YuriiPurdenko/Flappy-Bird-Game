using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController instance;

    [SerializeField] Text gameScore, bestScore, scoreText, gameOver;
    [SerializeField] Button pauseButton, resumeButton, instractionButton;
    [SerializeField] Sprite[] medals;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject[] birds;
    [SerializeField] Image medalImage;
    
    void Awake() {
        makeInstance();    
    }

    public void makeInstance(){
        if(instance == null){
            instance = this;
        }
    }

    public void pause(){
        if(BirdsMovementScript.instance != null){
            if(BirdsMovementScript.instance.isAlive){
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                gameOver.gameObject.SetActive(false);
                scoreText.text = "" + BirdsMovementScript.instance.score;
                
                if(BirdsMovementScript.instance.score > GameControllerScript.instance.getHihgScore()){
                    GameControllerScript.instance.setHihgScore(BirdsMovementScript.instance.score);
                }
                bestScore.text = "" + GameControllerScript.instance.getHihgScore();
                resumeButton.onClick.RemoveAllListeners();
                resumeButton.onClick.AddListener(() => resume());
            }
        }
    }

    public void resume(){
        pausePanel.SetActive(false);
        Time.timeScale = 1f;    
        }

    public void goToMenu(){

        SceneManager.LoadScene("MainMenu");
    }

     public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void startGame(){
        Debug.Log("pressed");
        gameScore.gameObject.SetActive(true);
        Debug.Log("gameScore.gameObject.SetActive(true);");
        birds[GameControllerScript.instance.getSelectedBird()].SetActive(true);
        Debug.Log("birds[GameControllerScript.instance.getSelectedBird()].SetActive(true);");
        instractionButton.gameObject.SetActive(false);
        Debug.Log("instractionButton.gameObject.SetActive(false);");
        Time.timeScale = 1f;
    }

    public void setScore(int score){
        gameScore.text = "" + score;
    }

    public void showDiedPanel(int score){
        pausePanel.SetActive(true);
        gameOver.gameObject.SetActive(true);
        gameScore.gameObject.SetActive(false);
        scoreText.text = "" + score;
        if(score > GameControllerScript.instance.getHihgScore()){
            GameControllerScript.instance.setHihgScore(score);
        }
        bestScore.text = "" + GameControllerScript.instance.getHihgScore();

        if(score <= 20){
            medalImage.sprite = medals[0];
        }
        else if( score > 20 && score < 40){
            medalImage.sprite = medals[1];
            if(!GameControllerScript.instance.isUnlockedGreenBird()){
                GameControllerScript.instance.UnlockGreenBird();
            }
        }
        else{
            medalImage.sprite = medals[2];
            if(!GameControllerScript.instance.isUnlockedGreenBird()){
                GameControllerScript.instance.UnlockGreenBird();
            }
            if(!GameControllerScript.instance.isUnlockedBlueBird()){
                GameControllerScript.instance.UnlockBlueBird();
            }
        }
        resumeButton.onClick.RemoveAllListeners();
        resumeButton.onClick.AddListener(() => restartGame());

    }
}
