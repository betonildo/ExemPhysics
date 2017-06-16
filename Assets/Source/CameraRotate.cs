using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

	public float zoomSpeed = 0.1f;
	public float zoomLevel = 0.0f;
	public float minZoom = -30f;
	public float maxZoom = 10f;
	public float minXrot = -45.0f;
	public float maxXrot = 45.0f;
	public float rotationSpeed = 1f;
	public Transform target;

	float rot_x;
	float rot_y;
	bool zoomingStarted = false;

	// Use this for initialization
	void Start () {
		zoomLevel = Camera.main.transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
		float zoomDelta = Input.mouseScrollDelta.y;
		zoomLevel += zoomDelta;

		if (Input.GetMouseButton (0)) {
			rot_x += Input.GetAxis ("Mouse X") * rotationSpeed;
			rot_y += Input.GetAxis ("Mouse Y") * rotationSpeed;
		}


		float z = Mathf.Sin (rot_x) * zoomLevel;
		float x = Mathf.Cos (rot_x) * zoomLevel;
		float y = Mathf.Cos (rot_y) * zoomLevel;

		Vector3 pos = new Vector3(x, y, z);
		Camera.main.transform.localPosition = pos;
		Camera.main.transform.LookAt (target);
	}

	void StartZooming() {

		Vector3 position = Camera.main.transform.forward;
		position.z = zoomLevel * zoomSpeed;
		Camera.main.transform.localPosition = position;
	}

}
