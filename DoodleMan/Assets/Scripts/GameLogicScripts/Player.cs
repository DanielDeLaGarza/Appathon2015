using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	// Basic Character Attributes
	public int health = 1;
	public float moveSpeed = 2f;

	protected Animator animator;
	private bool enemyInRange = false;			

	//Sets the right orintation of character walk left for enemies right for allies
	void Start ()
	{

	}
	
	void Update ()
	{
		move ();
	}

	//Subtracts from total health
	void ReceiveDamage (int damage)
	{
		health -= damage;

	}

	//kills characters by playing death animationa nd destroying object
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

	//Moves character in the right directon
	void Move ()
	{

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-0.2f * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.2f * moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

	}
	
}
