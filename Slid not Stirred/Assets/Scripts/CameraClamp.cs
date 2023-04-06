using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    Vector2 screenBounds;
    float objectWitdth;
    float objectHeight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        objectWitdth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x,screenBounds.x*-1 + objectWitdth,screenBounds.x-objectWitdth);
        viewPos.y = Mathf.Clamp(viewPos.y,screenBounds.x*-1 + objectHeight,screenBounds.y-objectHeight);
        transform.position = viewPos;
    }
}
