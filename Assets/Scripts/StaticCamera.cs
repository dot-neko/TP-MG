using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCamera : MonoBehaviour {
	public Transform target;
	public float distance;
	public float height;


	// Use this for initialization
	void Start () {
		CameraSetUp ();
	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate() {
		if (!target)
			return;
		// Always look at the target
		transform.LookAt(target);
	}

	protected void CameraSetUp() {
		transform.position = new Vector3 (target.position.x, target.position.y + height, target.position.z - distance);
		transform.LookAt (target);
	}	
}