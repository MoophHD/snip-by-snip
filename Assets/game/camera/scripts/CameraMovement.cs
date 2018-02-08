using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	private Vector3 startPos;
	private Transform tr;
	public float smoothSpeed = 0.3f;
	private Vector3 currentVelocity;
	// void LateUpdate () {
	// 	if (target.position.y > transform.position.y) {
	// 		Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
	// 		transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed * Time.deltaTime);
	// 	}
	// }
	private float speed;

	void Awake() {
		tr = GetComponent<Transform>();

		startPos = tr.position;
		speed = State.instance.scrollingSpeed;
	}
	void FixedUpdate () {
		
		Vector3 newPos = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
	}

	public void resetPos() {
		tr.position = startPos;
	}
}
