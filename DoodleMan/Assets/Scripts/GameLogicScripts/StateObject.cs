using UnityEngine;
using System.Collections;

public class StateObject : MonoBehaviour
{

	private int currState;
	int numberOfStates;

	// Use this for initialization
	void Start ()
	{
		currState = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// TODO: Animations for state-changes
	}

	void setState (int state)
	{

		while (state > numberOfStates) {
			state %= numberOfStates;
		}

		currState = state;

	}

}
