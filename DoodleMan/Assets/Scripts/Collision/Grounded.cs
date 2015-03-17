using UnityEngine;
using System.Collections;

public class Grounded : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D other)
	{
		this.GetComponentInParent<Player> ().setGrounded (true);
	}
	void OnTriggerExit2D (Collider2D other){
		this.GetComponentInParent<Player> ().setGrounded (false);
	}
}
