using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FaderSceneSript : MonoBehaviour
{
    // Start is called before the first frame update
    public static FaderSceneSript instance;
    [SerializeField]
    public GameObject fader;

    [SerializeField] 
    public Animator anim;
    void Awake() {
        makeSingleton();    
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


   public void fadeOut(){
       StartCoroutine(fadeOutCoroutine());
   }

  
   public void fadeIn(string levelName){
       StartCoroutine(fadeInCoroutine(levelName));
   }

   IEnumerator fadeInCoroutine(string levelName){
       fader.SetActive(true);
       anim.Play("FadeIn");
       yield return new WaitForSeconds(.3f);
       SceneManager.LoadScene(levelName);
       fadeOut();
   }

   IEnumerator fadeOutCoroutine(){
       anim.Play("FadeOut");
       yield return new WaitForSeconds(.5f);
       fader.SetActive(false);
   }

}
