using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
	//makes the camera follow the target if it goes higher up than the camera.
	public Transform target;
	void Update () {
		
		if ( target.position.y > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
		}
	}
}
