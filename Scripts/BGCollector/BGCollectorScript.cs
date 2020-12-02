using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollectorScript : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] backGround;
    GameObject[] ground;

    float lastBGPositionX;
    float lastGroundPositionX;


    void Awake()
    {
        backGround = GameObject.FindGameObjectsWithTag("BackGround");
        ground = GameObject.FindGameObjectsWithTag("Ground");


        lastBGPositionX = backGround[0].transform.position.x;
        lastGroundPositionX = ground[0].transform.position.x;
        for (int i = 1; i < backGround.Length; i++)
        {
            if (backGround[i].transform.position.x > lastBGPositionX)
            {
                lastBGPositionX = backGround[i].transform.position.x;
            }
        }
        for (int i = 1; i < ground.Length; i++)
        {
            if (ground[i].transform.position.x > lastGroundPositionX)
            {
                lastGroundPositionX = ground[i].transform.position.x;
            }
        }


    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        if(other.tag == "BackGround"){
            Vector3 temp = other.transform.position;
            temp.x = lastBGPositionX + ((BoxCollider2D)other).size.x;
            other.transform.position = temp;
            lastBGPositionX = temp.x;
        }   
        if(other.tag == "Ground"){
            Vector3 temp = other.transform.position;
            temp.x = lastGroundPositionX + ((BoxCollider2D)other).size.x;
            other.transform.position = temp;
            lastGroundPositionX = temp.x;
        }   
    }
 }
