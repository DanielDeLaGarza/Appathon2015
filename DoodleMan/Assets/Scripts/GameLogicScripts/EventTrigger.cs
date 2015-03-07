
using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour {
	
	private int currState;
	public GameObject[] toggleObjects, stateObjects;
	
	// Use this for initialization
	void Start () {
		currState = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Animation on lever pull or button press
	}
	
	private void cycleStates() {
		
		foreach (GameObject t in toggleObjects) {
			t.SendMessageUpwards("ToggleState", SendMessageOptions.DontRequireReceiver);
		}
		
		foreach (GameObject s in stateObjects) {
			currState++;

			s.SendMessageUpwards("SetState", currState, SendMessageOptions.DontRequireReceiver);
		}
		
	}
	
}
