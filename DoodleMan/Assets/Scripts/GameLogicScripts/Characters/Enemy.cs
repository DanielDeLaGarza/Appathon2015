using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public int health = 1, attackDamage = 1, xMin = 0, xMax = 0;
	public float moveSpeed = 2f, applyDamageRadius = 1, detectionRange = 10;

	protected Animator animator;
	private bool inRange = false;
	private int direction = 1;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (health <= 0) {
			Die ();
		}

		Vector3 scale = transform.localScale;
		if (direction == 1) {
			scale.x = Mathf.Abs(scale.x);
		} else {
			scale.x = Mathf.Abs(scale.x) * -1;
		}
		transform.localScale = scale;

		Patrol ();
		Move ();

	}

	void ReceiveDamage (int damage)
	{
		health -= damage;
	}

	void Die ()
	{
		this.gameObject.SetActive (false);
		Destroy (this.gameObject);
	}

	void Patrol() {

		if (this.gameObject.transform.position.x < xMin) {
			direction = 1;
		} else if (this.gameObject.transform.position.x > xMax) {
			direction = -1;
		}

	}

	// Direction < 0 indicates left movement, direction > 0 indicates right movement
	void Move ()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed * direction, GetComponent<Rigidbody2D> ().velocity.y);
	}

}
