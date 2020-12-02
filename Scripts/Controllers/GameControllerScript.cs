using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameControllerScript instance;

    private const string INIT_KEY = "GAME_STARTED_FOR_THE_FIRST_TIME";
    private const string BLUE_BIRD = "BLUE_BIRD";
    private const string GREEN_BIRD = "GREEN_BIRD";
    private const string SELECTED_BIRD = "SELECTED_BIRD";
    private const string HIGH_SCORE = "HIGH_SCORE";


    void Awake() {
        makeSingleton();
        initialized();

        
    }
    void Start()
    {
        
    }
    void makeSingleton(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }


    void initialized(){
        if(!PlayerPrefs.HasKey(INIT_KEY)){
            PlayerPrefs.SetInt(BLUE_BIRD,0);
            PlayerPrefs.SetInt(GREEN_BIRD,0);
            PlayerPrefs.SetInt(SELECTED_BIRD,0);
            PlayerPrefs.SetInt(HIGH_SCORE,0);
            PlayerPrefs.SetInt(INIT_KEY,0);
        }
    }

    public void setHihgScore(int score){
        PlayerPrefs.SetInt(HIGH_SCORE,score);
    }
    public int getHihgScore(){
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
    
    

    public void setSelectedBird(int selectedBird){
        PlayerPrefs.SetInt(SELECTED_BIRD,selectedBird);
    }
    public int getSelectedBird(){
       return  PlayerPrefs.GetInt(SELECTED_BIRD);
    }
    
    public void UnlockGreenBird(){
        PlayerPrefs.SetInt(GREEN_BIRD,1);
    }
    public bool isUnlockedGreenBird(){
       return  (PlayerPrefs.GetInt(GREEN_BIRD) == 1 ? true : false);
    }

    public void UnlockBlueBird(){
        PlayerPrefs.SetInt(BLUE_BIRD,1);
    }
    public bool isUnlockedBlueBird(){
       return  (PlayerPrefs.GetInt(BLUE_BIRD) == 1 ? true : false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
