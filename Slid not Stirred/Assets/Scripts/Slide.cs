using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public float forwardSpeed;
    public float backwardspeed;

    public Transform leftBeer;
    public Transform rightBeer;
    public Transform startPointL;
    public Transform endpointL;

    public Transform startPointR;
    public Transform endpointR;

    bool slide;

    // Update is called once per frame
    void Update()
    {
        //Right Beer
        if(rightBeer.position.x <= startPointR.position.x){
            slide = true;
        }

        if(rightBeer.position.x >= endpointR.position.x){
            slide = false;
        }

        if(slide){
            rightBeer.position = Vector3.Slerp(rightBeer.position,endpointR.position, forwardSpeed* Time.deltaTime);
           
        }
        
        if(!slide){
            rightBeer.position = Vector3.Slerp(rightBeer.position,startPointR.position, backwardspeed* Time.deltaTime);
        }
        

        //Left Beer
        if(leftBeer.position.x >= startPointL.position.x){
            slide = true;
        }

        if(leftBeer.position.x <= endpointL.position.x){
            slide = false;
        }

        if(slide){
            leftBeer.position = Vector3.Slerp(leftBeer.position,endpointL.position, forwardSpeed* Time.deltaTime);
           
        }
        
        if(!slide){
            leftBeer.position = Vector3.Slerp(leftBeer.position,startPointL.position, backwardspeed* Time.deltaTime);
        }


        
    }
}
