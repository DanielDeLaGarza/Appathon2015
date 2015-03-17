using UnityEngine;
using System.Collections;

public class ToggleTrigger : MonoBehaviour {

	public string functionName;
	
	void OnTriggerStay2D (Collider2D other)
	{
		this.gameObject.SendMessageUpwards(functionName, true, SendMessageOptions.DontRequireReceiver);
	}

	void OnTriggerExit2D (Collider2D other){
		this.gameObject.SendMessageUpwards(functionName, false, SendMessageOptions.DontRequireReceiver);
	}
}
