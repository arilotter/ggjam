using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	float movespeed = 10;
	float angle;


	public string player;

	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
		var direction = new Vector2(Input.GetAxis("P1 LX"), Input.GetAxis("P1 LY"));
		direction *= movespeed;
		rigidbody2D.AddForce(direction);

		var rightJoy = new Vector2(Input.GetAxis ("P1 RX"), Input.GetAxis ("P1 RY"));
		var faceDirection = (rightJoy != Vector2.zero ? rightJoy : (rigidbody2D.velocity));

		angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
