using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdsMovementScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static BirdsMovementScript instance;

    Button flapButton;

    [SerializeField]
    Rigidbody2D myRigidBody;

    [SerializeField]
    Animator anim;

    public bool isAlive;
    bool didFlap;
    public int score;
    float forwardSpeed = 3f;
    float upSpeed = 4f;

    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip died, point, flap;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        isAlive = true;
        flapButton = GameObject.FindGameObjectWithTag("Flap Button").GetComponent<Button>();
        flapButton.onClick.AddListener(() => FlapTheBird());
        SetCamerasX();
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;
            if (myRigidBody.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                float angel = 0;
                angel = Mathf.Lerp(0, -60, -myRigidBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angel);
            }

            if (didFlap)
            {
                didFlap = false;
                source.PlayOneShot(flap);
                myRigidBody.velocity = new Vector2(0, upSpeed);
                anim.SetTrigger("Move");
            }
        }
    }

    void SetCamerasX()
    {
        CameraMovementScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }
    public void FlapTheBird()
    {
        didFlap = true;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ground" || other.transform.tag == "Pipe")
        {
            if (isAlive)
            {
                isAlive = false;
                anim.SetTrigger("Died");
                source.PlayOneShot(died);
                GamePlayController.instance.showDiedPanel(score);
            }   
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PipeHolders")
        {
            score++;
            GamePlayController.instance.setScore(score);
            source.PlayOneShot(point);
        }
    }
}
