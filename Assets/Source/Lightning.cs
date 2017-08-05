using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

	float m_offset = 0.0f;
	float m_speed = 0.0f;
	float m_walkSpeed = 0.1f;
	float percentage = 0.0f;
	GameObject lightningObject;

	void Start() {
		m_offset = Random.Range (0.0f, 100.0f) / 100.0f;
		transform.localRotation = Random.rotation;
		lightningObject = gameObject.transform.GetChild (0).gameObject;
		StartRotationScheduler ();
	}

	public void setSpeed(float speed) {
		m_speed = speed;
	}

	public void setWalkSpeed(float walkSpeed) {
		m_walkSpeed = walkSpeed;
	}

	// Update is called once per frame
	void Update () {
		m_offset += m_speed * Time.deltaTime;
		updateTilling ();
		updateShowRotationToTheMainCamera ();
	}

	void updateTilling() {
		lightningObject.GetComponent<MeshRenderer> ().sharedMaterial.mainTextureOffset = new Vector2 (0, m_offset);
	}

	void updateShowRotationToTheMainCamera() {
		Quaternion lookAtCam = Quaternion.LookRotation (Camera.main.transform.eulerAngles);
		Quaternion current = lightningObject.transform.localRotation;
		Vector3 euler = current.eulerAngles;
		euler.y = lookAtCam.eulerAngles.y;
		lightningObject.transform.localRotation = Quaternion.Euler (euler);
	}

	void StartRotationScheduler() {
		StartCoroutine (rotationScheduler ());
	}

	IEnumerator rotationScheduler() {
		while (true) {
			percentage = 0.0f;
			Quaternion current = gameObject.transform.localRotation;
			Quaternion next = Random.rotation;

			while (percentage < 1.0f) {
				
				Quaternion pace = Quaternion.Slerp (current, next, percentage);
				percentage += m_walkSpeed * Time.deltaTime;
				transform.localRotation = pace;

				yield return null;
			}

			yield return null;
		}
	}
}
