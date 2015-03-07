using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public int health = 1, attackDamage = 1, xMin = 0, xMax = 0;
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

		if (enemyInRange) {
			Follow ();
		} else {
			Patrol ();
		}

	}

	void ReceiveDamage (int damage)
	{
		health -= damage;
	}

	void Die ()
	{
		this.gameObject.SetActive (false);
		GameObject dieEffect = (GameObject)Instantiate (Resources.Load ("Effects/Die"));
		dieEffect.transform.parent = this.gameObject.transform;
		dieEffect.transform.localPosition = new Vector3 (0, 1, 0);
		dieEffect.transform.localScale = new Vector3 (1, 1, 1);
		dieEffect.transform.parent = null;
		Destroy (this.gameObject);
		Destroy (dieEffect, 2);
	}

	void Patrol() {

	}

	void Follow() {

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
