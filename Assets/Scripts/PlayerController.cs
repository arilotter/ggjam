using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	float movespeed = 5;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		var direction = new Vector2( Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		direction *= movespeed;
		rigidbody2D.AddForce(direction);
	}
}
