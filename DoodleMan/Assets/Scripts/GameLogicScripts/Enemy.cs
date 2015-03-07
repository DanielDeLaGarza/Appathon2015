using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public int health = 1, attackDamage = 1;
	public float moveSpeed = 2f, applyDamageRadius = 1, detectionRange = 4;
	protected Animator animator;
	private Component attackPoint;
	private bool enemyInRange = false;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
		attackPoint = transform.Find ("AttackPoint").GetComponent<Component> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (health <= 0) {
			Die ();
		}
	}

	Collider2D ApplyDamage ()
	{

		// TODO: Change this value to the player's layer
		int layer_bitmask = 1000;

		Vector2 location = new Vector2 (this.attackPoint.transform.position.x, this.attackPoint.transform.position.y);

		Collider2D[] targets = Physics2D.OverlapCircleAll (location, applyDamageRadius, layer_bitmask);

		// There will only ever be one target: the player
		return targets [0];

	}

	void ReceiveDamage (int damage)
	{
		health -= damage;
	}

	void Die ()
	{
		this.gameObject.SetActive (false);
		GameObject dieEffect = (GameObject)Instantiate (Resources.Load ("Effects/Die"));
		// TODO: Death animation
		Destroy (this.gameObject);
		Destroy (dieEffect, 2);
	}

	// Direction < 0 indicates left movement, direction > 0 indicates right movement
	void Move (byte direction)
	{

		if (direction < 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-0.2f * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.2f * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

	}

}
