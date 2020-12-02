using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuControllerScript : MonoBehaviour
{

    public static MenuControllerScript instance;

    [SerializeField]
    private GameObject[] birds;


    //[SerializeField]
    //private Animator notificationAnim;

    //[SerializeField]
    //private Text notificationText;

    void Awake()
    {
        makeInstance();
    }

    void Start()
    {
        birds[GameControllerScript.instance.getSelectedBird()].SetActive(true);
    }

    void makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

    }


    public void playGame()
    {
        FaderSceneSript.instance.fadeIn("GamePlay");
    }
    /*
	public void ConnectOnGooglePlayGames() {
		LeaderboardsController.instance.ConnectOrDisconnectOnGooglePlayGames ();
	}

	public void OpenLeaderboardsScoreUI() {
		LeaderboardsController.instance.OpenLeaderboardsScore ();
	}

	public void ConnectOnTwitter() {
		SocialMediaController.instance.LogInOrLogOutTwitter ();
	}

	public void ShareOnTwitter() {
		SocialMediaController.instance.ShareOnTwitter ();
	}
	 */
    public void ChangeBird()
    {
        if (GameControllerScript.instance.getSelectedBird() == 0)
        {

            if (GameControllerScript.instance.isUnlockedGreenBird())
            {
                birds[0].SetActive(false);
                GameControllerScript.instance.setSelectedBird(1);
                birds[GameControllerScript.instance.getSelectedBird()].SetActive(true);
            }

        }
        else if (GameControllerScript.instance.getSelectedBird() == 1)
        {
            if (GameControllerScript.instance.isUnlockedBlueBird())
            {
                birds[1].SetActive(false);
                GameControllerScript.instance.setSelectedBird(2);
                birds[GameControllerScript.instance.getSelectedBird()].SetActive(true);

            }
            else
            {
                birds[1].SetActive(false);
                GameControllerScript.instance.setSelectedBird(0);
                birds[GameControllerScript.instance.getSelectedBird()].SetActive(true);

            }

        }
        else if (GameControllerScript.instance.getSelectedBird() == 2)
        {
            birds[2].SetActive(false);
            GameControllerScript.instance.setSelectedBird(0);
            birds[GameControllerScript.instance.getSelectedBird()].SetActive(true);
        }

    }

    /* 	public void NotificationMessage(string message) {
            StartCoroutine (AnimateNotificationPanel(message));
        }

        IEnumerator AnimateNotificationPanel(string message) {
            notificationAnim.Play("SlideIn");
            notificationText.text = message;
            yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(2f));
            notificationAnim.Play("SlideOut");
        }
     */

} // class































































