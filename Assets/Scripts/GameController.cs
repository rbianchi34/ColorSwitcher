using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public List<GameObject> objectList;
	public GameObject finishLine;
	public float objectSpacing = 4.00f;
	private float nextSpawnPoint = 4.00f;


	// Use this for initialization
	void Start () {
		SpawnObjects (); 
		SpawnObjects (finishLine);
	}


	void SpawnObjects(){

		foreach (var item in objectList) {
			
			//calculate height of object. 
			//This really depends on wheter you're calculating directly from an object with a SpriteRenderer OR from an object that contains multiple ones, like the circle.
			float itemHeight = 0.00f;

		
			if (item.tag == "Circle") {
				itemHeight = item.transform.GetChild (0).GetComponent<SpriteRenderer> ().bounds.size.y;
			}

			if (item.tag == "ColorChanger") {
				itemHeight = item.GetComponent<SpriteRenderer> ().bounds.size.y;
			}

			//set spawn position and rotation of item
			Vector3 spawnPos = new Vector3 (item.transform.position.x, nextSpawnPoint + itemHeight, item.transform.position.z);
			Quaternion spawnRotation = Quaternion.identity;

			//add height of object and spacing to get the next spawn point
			nextSpawnPoint = nextSpawnPoint + itemHeight + objectSpacing;

			//instantiate the object
			Instantiate (item, spawnPos, spawnRotation);
		}

	}

	void SpawnObjects(GameObject item){
		
		//calculate height of object. 
		float itemHeight = item.GetComponent<SpriteRenderer> ().bounds.size.y;

		//set spawn position and rotation of item
		Vector3 spawnPos = new Vector3 (item.transform.position.x, nextSpawnPoint + itemHeight, item.transform.position.z);
		Quaternion spawnRotation = Quaternion.identity;

		//add height of object and spacing to get the next spawn point
		nextSpawnPoint = nextSpawnPoint + itemHeight + objectSpacing;

		//instantiate the object
		Instantiate (item, spawnPos, spawnRotation);

	}
}
