using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterpolateTranslateLeft: MonoBehaviour {

	public Button menuAccessButton;
	public float speed = 10f;
	public float width = 0f;
	public float height = 0f;
	public float percentage = 0f;
	public Vector3 endPosition = Vector3.zero;
	public Vector3 startPosition = Vector3.zero;

	int m_direction = 1;

	void Start() {
		menuAccessButton.onClick.AddListener (startTransition);
		endPosition.x = width = ((RectTransform)transform).rect.width;
		startPosition.y = endPosition.y = height = ((RectTransform)transform).rect.height/2;
	}

	void startTransition() {
		menuAccessButton.interactable = false;
		if (m_direction > 0) StartCoroutine (translate (1, 1.0f));
		else StartCoroutine (translate (-1, 0.0f));

		m_direction *= -1;
	}

	IEnumerator translate(int direction, float endPercentage) {
		
		RectTransform currentRect = ((RectTransform)transform);

		while (endPercentage - percentage * direction > 0f) {
			
			currentRect.position = Vector3.Lerp (startPosition, endPosition, percentage);
			Debug.Log (currentRect.position);
			percentage += (0.1f * Time.deltaTime) * direction * speed;

			yield return null;
		}

		percentage = endPercentage;

		menuAccessButton.interactable = true;
	}
}
