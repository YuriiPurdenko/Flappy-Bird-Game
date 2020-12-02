using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public static float offsetX;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(BirdsMovementScript.instance != null && BirdsMovementScript.instance.isAlive){
            MoveCamera();
        }
        
    }

    void MoveCamera(){
        Vector3 temp = transform.position;
        temp.x = BirdsMovementScript.instance.GetPositionX() + offsetX;
        transform.position = temp;
    }
}
