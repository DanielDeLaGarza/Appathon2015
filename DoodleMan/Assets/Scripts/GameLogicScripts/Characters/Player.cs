using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	// Basic Character Attributes
	public int health = 1;
	public float moveSpeed = 2f;
	protected Animator animator;
	private bool canJump = true;

	private bool left = false, right = false, up = false;

	//Sets the right orintation of character walk left for enemies right for allies
	void Awake ()
	{
		animator = GetComponent<Animator> ();
	}
	
	void Update ()
	{
		Move ();
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

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			left = true;
			Vector3 inverseScale = transform.localScale;
			if(inverseScale.x > 0)inverseScale.x *= -1;
			transform.localScale = inverseScale;
			animator.SetBool("isRunning", true);
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			left = false;
			animator.SetBool("isRunning", false);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			right = true;
			Vector3 scale = transform.localScale;
			if(scale.x < 0)scale.x *= -1;
			transform.localScale = scale;
			animator.SetBool("isRunning", true);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			right = false;
			animator.SetBool("isRunning", false);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			animator.SetBool("isJumping", true);
			up = true;
		}
		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			up = false;
		}
		if (left){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-5.3f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (right){
			GetComponent<Rigidbody2D>().velocity = new Vector2(5.3f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (!(left || up || right)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (GetComponent<Rigidbody2D>().velocity.y < 0) {
			animator.SetBool ("isFalling", true);
		} 
		else {
			animator.SetBool ("isFalling", false);
		}
		if (GetComponent<Rigidbody2D>().velocity.y > 0) {
			animator.SetBool ("isJumping", true);
		} 
		else {
			if(!up) animator.SetBool ("isJumping", false);
		}

	}
	void jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 8);
	}
	
}
