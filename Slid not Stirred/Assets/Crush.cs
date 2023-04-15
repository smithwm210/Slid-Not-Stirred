using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    // Start is called before the first frame update
    public float upspeed;
    public float downspeed;
    public Transform up;
    public Transform down;
    bool chop;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= up.position.y){
            chop = true;
        }

        if(transform.position.y <= down.position.y){
            chop = false;
        }

        if(chop){
            transform.position = Vector3.Slerp(transform.position,down.position, downspeed* Time.deltaTime);
           
        }
        
        if(!chop){
            transform.position = Vector3.Slerp(transform.position,up.position, upspeed* Time.deltaTime);
        }

        
    }
}
