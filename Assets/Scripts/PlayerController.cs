using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	float movespeed = 10;

	float rotationSpeed = 5;

	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
		var direction = new Vector2( Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		direction *= movespeed;
		rigidbody2D.AddForce(direction);
		if (direction != Vector2.zero) {
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
