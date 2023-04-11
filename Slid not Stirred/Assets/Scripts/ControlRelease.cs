using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRelease : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        FindObjectOfType<PlayerController2>().enabled = false;
        FindObjectOfType<PlayerController2>().GetComponent<Rigidbody2D>().velocity 
        = new Vector2(5,0); 
    }

}
