using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRotation : MonoBehaviour {

    public Transform player;
    public float rotationSpeed = 1;
    public float maxAngleUp = 20;
    public float maxAngleDown= 45;

    private float currentAngle = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    void Rotate()
    {
        float deltaRotation = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        currentAngle += deltaRotation;
        currentAngle = Mathf.Clamp(currentAngle, -maxAngleDown, maxAngleUp);

        float angleInRadians = currentAngle * Mathf.Deg2Rad;
        Vector3 newLookAtDirection = Mathf.Cos(angleInRadians) * player.forward + Mathf.Sin(angleInRadians) * player.up;
        Vector3 newLookAtPoint = transform.position + newLookAtDirection;
        transform.LookAt(newLookAtPoint);
    }
}
