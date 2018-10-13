using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : Controller {

    private float maxSpeed = 20f;
    private float timeToMaxSpeed = 10f;
    private float accelRate;

    //private float slowDown = 0.5f;
    private float rotationSpeed = 3f;

    private float forwardVelocity;
    private Vector3 moveDir = Vector3.zero;
    


	
    // Use this for initialization
	void Start () {
        accelRate = maxSpeed / timeToMaxSpeed;
        forwardVelocity = 0f;
    }
	
	// Update is called once per frame
	void Update () {

        CharacterController controller = gameObject.GetComponent<CharacterController>();
        FnBMovement (controller);
        RotateLR();
        
        

    }



    void FnBMovement ( CharacterController controller )
    {
        //if (Input.GetAxis("Vertical") > 0)
        //{

        //}
        //rb.velocity = transform.forward * forwardVelocity;

        forwardVelocity += accelRate;
        forwardVelocity = Mathf.Min(forwardVelocity, maxSpeed);

        moveDir = new Vector3(0, 0, Input.GetAxis("Vertical") * forwardVelocity);

        moveDir = transform.TransformDirection(moveDir);

        controller.Move(moveDir * Time.deltaTime);
    }  

    void RotateLR ()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0); }
        }
}


