using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollectorScript : MonoBehaviour
{
    // Start is called before the first frame update


    GameObject[] pipeHolders;
    float maxDistance = 7f;
    float minDistance = 3f;
    float maxY = 0.5f;
    float minY = -3.5f;
    float lastPipePositionX;

   

    void Awake()
    {
        pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolders");

        for (int i = 0; i < pipeHolders.Length; i++)
        {
            Vector3 temp = pipeHolders[i].transform.position;
            temp.y = Random.Range(minY, maxY);
            pipeHolders[i].transform.position = temp;
        }
        lastPipePositionX = pipeHolders[0].transform.position.x;
        for (int i = 1; i < pipeHolders.Length; i++)
        {
            if (lastPipePositionX < pipeHolders[i].transform.position.x)
            {
                lastPipePositionX = pipeHolders[i].transform.position.x;
            }
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PipeHolders")
        {
            Vector3 temp = other.transform.position;
            temp.y = Random.Range(minY, maxY);
            temp.x = lastPipePositionX + Random.Range(minDistance, maxDistance);
            other.transform.position = temp;
            lastPipePositionX = temp.x;
        }
    }

}
