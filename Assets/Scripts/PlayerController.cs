using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	float movespeed = 10;

	float angle;
	
	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
		var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		direction *= movespeed;
		rigidbody2D.AddForce(direction);

		var faceDirection = new Vector2(Input.GetAxis ("Shoot X"), Input.GetAxis ("Shoot Y"));
		if (faceDirection != Vector2.zero) {
			angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
