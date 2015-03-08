using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D other)
	{
		other.SendMessage ("Die", SendMessageOptions.DontRequireReceiver);
	}
	
}
