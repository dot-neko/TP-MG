using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : StaticCamera {
	public float rotationDamping = 2.0f;
	public float heightDamping = 3.0f;


	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate() {

		if (!target)
			return;

		// Calculate the current rotation angles
		var wantedRotationAngle = target.eulerAngles.y;
		var wantedHeight = target.position.y + height;

		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;

		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		// Damp the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the height of the camera
		transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);

		// Always look at the target
		transform.LookAt(target);
	}
}
