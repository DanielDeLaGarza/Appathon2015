using UnityEngine;
using System.Collections;

public class FootTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		this.SendMessageUpwards("NotFalling",SendMessageOptions.DontRequireReceiver);
	}
}
