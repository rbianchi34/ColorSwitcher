using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float jumpForce = 10f;	
	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public List<Colors> colors = new List<Colors>();
	

	private Colors currentColor;
	private bool firstColorSet = false;

	void Start ()
	{
		SetRandomColor();
		
		
	}

	void Update (){
		
		if ( Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			//This makes it not go off-screen before first jump
			if (rb.gravityScale == 0)
			{
				rb.gravityScale = 3;
			}
			rb.velocity = Vector2.up * jumpForce;
		}
	}

	//CALLED WHEN IT COLLIDES WITH SOMETHING
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "ColorChanger")
		{
			SetRandomColor();
			Destroy(col.gameObject);
			return;
		}
		if (col.tag == currentColor.name)
		{
			Debug.Log ("You Pass!");
		}
		else
		{
			Debug.Log ("Game");
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		

	}

	void SetRandomColor ()
	{
		Colors old = currentColor;
		//Random.Range is min inclusive and max exclusive, so
		int index = Random.Range(0,colors.Count);

		currentColor = colors[index];
		sr.color = colors[index].color;

		if (firstColorSet) {
			while (colors [index].CompareTo (old) == 1) {
				SetRandomColor ();
			}
		}

		firstColorSet = true;

	}
}
