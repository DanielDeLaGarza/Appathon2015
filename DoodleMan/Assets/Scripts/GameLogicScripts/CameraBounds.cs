using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.x > -16 && this.gameObject.transform.position.x < 7)
			GetComponent<Rigidbody2D>().velocity = new Vector2(-5, GetComponent<Rigidbody2D>().velocity.y);
	}
}
