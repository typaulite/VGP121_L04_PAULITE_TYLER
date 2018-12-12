using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform target;
    public float lerpSpeed = 10;
    public float offsetX = -5;
    public float offsetY = 0;
    public float offsetZ = -5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Set the postion relative to the target by offset
        Vector3 newPosition = target.position;
        newPosition += offsetX * target.right;
        newPosition += offsetY * target.up;
        newPosition += offsetZ * target.forward;
        transform.position = Vector3.Lerp(transform.position, newPosition, lerpSpeed * Time.deltaTime);

        // Rotate with the target
        transform.LookAt(target);
	}
}
