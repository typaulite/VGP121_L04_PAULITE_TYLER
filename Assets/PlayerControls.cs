using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float forwardSpeed = 10;
    public float sidewaysSpeed = 5;
    public float jumpForce = 10;
    public float rotationSpeed = 1;
    public Weapon weapon;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Jump();
        Rotate();
        Shoot();
	}

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //GET HORIZONTAL MOVEMENT AND ADD THAT TO POSITION
        Vector3 horizontal = Input.GetAxis("Horizontal") * sidewaysSpeed * transform.right;
        //GET FORWARD MOVEMENT AND ADD THAT TO POSITION
        Vector3 forward = Input.GetAxis("Vertical") * forwardSpeed * transform.forward;

        rb.AddForce(horizontal + forward);
        //transform.position += horizontal + forward;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }

    void Rotate()
    {
        float deltaRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        Vector3 newLookAtDirection = transform.forward + deltaRotation * transform.right;
        Vector3 newLookAtPoint = transform.position + newLookAtDirection;
        transform.LookAt(newLookAtPoint);
    }

    void Shoot()
    {
        weapon.Fire(Input.GetButtonDown("Fire1"));
    }
}
