using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public float forwardSpeed;
    public float backwardspeed;
    public Transform startPoint;
    public Transform endpoint;
    bool slide;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= startPoint.position.x){
            slide = true;
        }

        if(transform.position.x <= endpoint.position.x){
            slide = false;
        }

        if(slide){
            transform.position = Vector3.Slerp(transform.position,endpoint.position, forwardSpeed* Time.deltaTime);
        }
        
        if(!slide){
            transform.position = Vector3.Slerp(transform.position,startPoint.position, backwardspeed* Time.deltaTime);
        }

        
    }
}
