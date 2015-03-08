using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	// Basic Character Attributes
	public int health = 1;
	public float jumPdelay = 1f;
	public float jumpVelocity = 7f;
	protected Animator animator;
	private float nextUsage = 0f;
	private float moveSpeed = 2f;

	private bool left = false, right = false, up = false;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(transform.gameObject);
		animator = GetComponent<Animator> ();
	}

	void Update ()
	{
		if(nextUsage > 0) nextUsage = nextUsage - Time.deltaTime;
		moveAcelerometer();
	}

	void Die ()
	{
		this.gameObject.SetActive (false);
		Destroy (this.gameObject);
		Application.LoadLevel (Application.loadedLevel);
	}

	//Moves character in the right directon
	void moveAcelerometer(){

		moveSpeed = Input.acceleration.x * 10f;
		Vector3 scale = transform.localScale;
		if (moveSpeed < -.6f) {
			scale.x = Mathf.Abs (scale.x) * -1;
		} else if (moveSpeed > .6f) {
			scale.x = Mathf.Abs (scale.x);
		}
		transform.localScale = scale;
		if (moveSpeed > -1f && moveSpeed < 1f) {
			animator.SetBool ("isRunning", false);
			animator.SetBool ("isWalking", false);
		} else if (Mathf.Abs (moveSpeed) > 3.5) {
			animator.SetBool ("isRunning", true);
			animator.SetBool ("isWalking", false);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			animator.SetBool ("isRunning", false);
			animator.SetBool ("isWalking", true);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}

	//////////////////////////////////////////////////////
	private void moveKeys(){
		animator.SetBool ("isWalking", false);
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
			Vector3 scaleNormal = transform.localScale;
			if(scaleNormal.x < 0)scaleNormal.x *= -1;
			transform.localScale = scaleNormal;
			animator.SetBool("isRunning", true);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			right = false;
			animator.SetBool("isRunning", false);
		}
		if (left){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (right){
			GetComponent<Rigidbody2D>().velocity = new Vector2(2f, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (!(left || right)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
	public void jump(){
		if (nextUsage <= 0) {
			nextUsage = jumPdelay;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpVelocity);
		}

	}
}
