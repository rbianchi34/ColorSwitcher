using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float minSpeed = 90f;
	public float maxSpeed = 200f;
	public Rigidbody2D rb;

	private float speed;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		speed = setSpeed ();
		Debug.Log ("Speed: " + speed);

	}
	
	// Update is called once per frame
	void Update () {
		rb.MoveRotation(rb.rotation + speed * Time.deltaTime);
	}

	float setSpeed ()
	{
		//randomizes speed
		float speed = Random.Range (minSpeed, maxSpeed);


		//randomizes if it goes forwards or backwards
		float backwards = Random.value;


		//the values of minSpeed and maxSpeed are positive if it's going forward
		if (backwards >= 0.5f) {
			Debug.Log ("Backwards?: YES");

			return -speed;

		} else {
			Debug.Log ("Backwards?: NO");

			return speed;
		}

	}
}
