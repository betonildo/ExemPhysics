using UnityEngine;
using System.Collections.Generic;

public class LightningEmmiter : MonoBehaviour {

	public float speed = -2.0f;

	[Range(0.0f, 1.0f)]
	public float walkSpeed = 0.1f;
	public int numberOfInstances = 10;
	private float lastSpeed = 0.0f;
	private float lastWalkSpeed = 0.1f;
	public Lightning[] lightnings;
	List<Lightning> lightningInsts = new List<Lightning>();

	// Use this for initialization
	void Start () {
		createLightningShapes ();

	}

	// Update is called once per frame
	void Update () {

		if (lastSpeed != speed) {
			lastSpeed = speed;
			for (var i = 0; i < lightningInsts.Count; i++) {
				lightningInsts [i].setSpeed(speed);
			}
		}

		if (lastWalkSpeed != walkSpeed) {
			lastWalkSpeed = walkSpeed;
			for (var i = 0; i < lightningInsts.Count; i++) {
				lightningInsts [i].setWalkSpeed(walkSpeed);
			}
		}
	}


	void createLightningShapes() {
		for (var i = 0; i < numberOfInstances; i++) {
			int linghtningIndex = i % lightnings.Length;
			instantiateLightining (lightnings [linghtningIndex]);
		}
	}

	void instantiateLightining(Lightning lightning) {
		Lightning instance = (Lightning)GameObject.Instantiate ((Object)lightning, transform);
		lightningInsts.Add (instance);
	}

}
