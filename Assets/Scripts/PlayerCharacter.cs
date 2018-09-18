using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    public Rigidbody2D myRigidbody;
	// Use this for initialization
	void Start () {

        Debug.Log("This is start");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.D))
        {
            // TO DO: move the character to the right!
            myRigidbody.velocity = new Vector2(5, myRigidbody.velocity.y);
        }
      // This is the syntax for printing to the console!
      //  Debug.Log("Test");
	}
}
