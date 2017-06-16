using UnityEngine;
using System.Collections.Generic;

public class LightningEmmiter : MonoBehaviour {

	public float speed = -2.0f;
	public int numberOfInstances = 10;
	private float lastSpeed = 0.0f;
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
			Debug.Log ("Change Speed!");
			for (var i = 0; i < lightningInsts.Count; i++) {
				lightningInsts [i].setSpeed(speed);
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
