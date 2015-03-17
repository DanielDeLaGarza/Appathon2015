using UnityEngine;
using System.Collections;

public class Murderize : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == 10) {
			other.SendMessageUpwards("die",SendMessageOptions.DontRequireReceiver);
		}
	}
}
