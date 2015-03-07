using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour {

	private bool currState;

	// Use this for initialization
	void Start () {
		currState = false;
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Animation for state change
	}

	void toggleState() {

		if (currState) {
			currState = false;
		} else {
			currState = true;
		}

	}

}
