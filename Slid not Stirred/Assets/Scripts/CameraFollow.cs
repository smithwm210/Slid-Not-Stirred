using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{

    public Transform followTransform;
    public float xOffset;
    public float yOffset;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x + xOffset, 2.39f , this.transform.position.z);
        
        
    }
}