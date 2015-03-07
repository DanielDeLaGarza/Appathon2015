using UnityEngine;
using System.Collections;

public class FootTrigger : MonoBehaviour {
	

	void OnTriggerStay2D(Collider2D other){
		SendMessageUpwards("NotFalling",SendMessageOptions.DontRequireReceiver);
	}
}
