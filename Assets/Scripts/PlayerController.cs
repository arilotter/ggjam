using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float movespeed = 5;
	float angle;


	public int playerNum;
	public Weapon weapon;

	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
		var direction = new Vector2(Input.GetAxis("P" + playerNum + " LX"), Input.GetAxis("P" + playerNum + " LY"));
		direction *= movespeed;
		rigidbody2D.AddForce(direction);

		var rightJoy = new Vector2(Input.GetAxis ("P" + playerNum + " RX"), Input.GetAxis ("P" + playerNum + " RY"));
		var faceDirection = (rightJoy != Vector2.zero ? rightJoy : (rigidbody2D.velocity));

		angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if(Input.GetAxis("P" + playerNum + " Shoot") < 0.4) { // right trigger pressed
			weapon.fireGun();
		}
	}
}
