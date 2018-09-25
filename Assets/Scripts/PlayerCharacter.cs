using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float size = 5, strength = 10, height, weight;

    private float moveInput;

    // Use this for initialization
    void Start () {

        Debug.Log("This is the start");
	}
 

	// Update is called once per frame
	void Update () 
        {
            GetMovementInput();
        }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetMovementInput()
    {
        moveInput = Input.GetAxis("Horizontal");

    }

    private void Move()
    {
        //Dont use transform.Translate because we are using physics!
        // transform.Translate(speed, 0, 0);
        myRigidbody.velocity = new Vector2(moveInput * speed, myRigidbody.velocity.y);
    }

    private void Jump()
    {
        //TODO make the character jump!
    }

    // This is the syntax for printing to the console!
    //  Debug.Log("Test");
}

